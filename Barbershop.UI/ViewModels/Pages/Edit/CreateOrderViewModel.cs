using Barbershop.Contracts.Models;
using Barbershop.UI.Converters;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using HandyControl.Tools.Extension;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Barbershop.Services.Services;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public sealed class CreateOrderViewModel : BaseViewModel
{
    private bool _isLoaded = false;

    private readonly BarberService _barberService;
    private readonly ClientService _clientService;
    private readonly OrderService _orderService;
    private readonly OfferService _offerService;

    private IReadOnlyList<BarberDto> _barbers;
    private IReadOnlyList<ClientDto> _clients;

    public int SelectedTabIndex
    {
        get => GetValue<int>(nameof(SelectedTabIndex));
        set => SetValue(value, () => { if (value == 3) FilterTimeSlots(); }, nameof(SelectedTabIndex));
    }
    public string SearchBarberText
    {
        get => GetValue<string>(nameof(SearchBarberText));
        set => SetValue(value, () => BarbersView.Refresh(), nameof(SearchBarberText));
    }
    public string SearchClientText
    {
        get => GetValue<string>(nameof(SearchClientText));
        set => SetValue(value, () => ClientsView.Refresh(), nameof(SearchClientText));
    }

    public decimal TotalCost
    {
        get => GetValue<decimal>(nameof(TotalCost));
        set => SetValue(value, nameof(TotalCost));
    }
    public int TotalMinutes
    {
        get => GetValue<int>(nameof(TotalMinutes));
        set => SetValue(value, nameof(TotalMinutes));
    }

    public ICollectionView BarbersView { get; set; }
    public ICollectionView ClientsView { get; set; }

    public DateTime? SelectedDate
    {
        get => GetValue<DateTime?>(nameof(SelectedDate));
        set => SetValue(value, () =>
        {
            FilterTimeSlots();
            RaisePropertyChanged(nameof(CanCreateOrder));
        }, nameof(SelectedDate));
    }
    public TimeSlot? SelectedTimeSlot
    {
        get => GetValue<TimeSlot>(nameof(SelectedTimeSlot));
        set => SetValue(value, () => RaisePropertyChanged(nameof(CanCreateOrder)), nameof(SelectedTimeSlot));
    }
    public bool CanCreateOrder => SelectedDate != null && SelectedTimeSlot != null;

    public IReadOnlyList<TimeSlot> TimeSlots { get; set; }

    public BarberDto SelectedBarber
    {
        get => GetValue<BarberDto>(nameof(SelectedBarber));
        set => SetValue(
            value,
            () =>
            {
                if (value == null)
                    ResetServices();
            },
            nameof(SelectedBarber));
    }
    public ClientDto SelectedClient
    {
        get => GetValue<ClientDto>(nameof(SelectedClient));
        set => SetValue(value, nameof(SelectedClient));
    }

    public ObservableCollection<ServiceDto> Services { get; set; } = new();
    public ServiceDto ServiceToSelect
    {
        get => GetValue<ServiceDto>(nameof(ServiceToSelect));
        set => SetValue(value, nameof(ServiceToSelect));
    }

    public ObservableCollection<ServiceDto> SelectedServices { get; set; } = new();
    public ServiceDto SelectedService
    {
        get => GetValue<ServiceDto>(nameof(SelectedService));
        set => SetValue(value, nameof(SelectedService));
    }

    public ICommand SelectServiceCommand { get; set; }
    public ICommand RemoveSelectedServiceCommand { get; set; }
    public ICommand BarberChangedCommand { get; set; }
    public ICommand SelectTimeSlotCommand { get; set; }
    public ICommand CreateOrderCommand { get; set; }

    public event Action OnOrderCreateCall;

    public CreateOrderViewModel(BarberService barberService, ClientService clientService, OrderService orderService, OfferService offerService)
    {
        _barberService = barberService;
        _clientService = clientService;
        _orderService = orderService;
        _offerService = offerService;

        BarbersView = CollectionViewSource.GetDefaultView(_barbers);
        SelectedDate = DateTime.Now;

        LoadViewDataCommand = new AsyncCommand(LoadView);

        SelectServiceCommand = new DelegateCommand(SelectService, () => ServiceToSelect != null);
        RemoveSelectedServiceCommand = new DelegateCommand(RemoveSelectedService, () => SelectedService != null);
        SelectTimeSlotCommand = new DelegateCommand<RoutedEventArgs>(SelectTimeSlot);
        CreateOrderCommand = new DelegateCommand(CreateOrder);
    }

    private async Task LoadView()
    {
        if (!_isLoaded)
        {
            _clients = await _clientService.GetAll();
            ClientsView = CollectionViewSource.GetDefaultView(_clients);
            ClientsView.Filter += FilterClient;

            _barbers = await _barberService.GetAll();
            BarbersView = CollectionViewSource.GetDefaultView(_barbers);
            BarbersView.Filter += FilterBarber;

            var _services = await _offerService.GetAll();
            Services = new ObservableCollection<ServiceDto>(_services.OrderBy(x => x.Id));

            var timeSlots = new List<TimeSlot>();
            var startTime = new TimeOnly(9, 0);
            for (int i = 0; i < 24; i++)
            {
                timeSlots.Add(new(startTime.AddMinutes(i * 30)));
            }
            TimeSlots = new ObservableCollection<TimeSlot>(timeSlots);

            RaisePropertiesChanged(nameof(ClientsView), nameof(BarbersView), nameof(Services), nameof(TimeSlots));
            _isLoaded = true;
        }
    }

    private void ResetServices()
    {
        SelectedTimeSlot = null;
        SelectedDate = null;
        TotalCost = 0;
        TotalMinutes = 0;

        if (SelectedServices.Count > 0)
        {
            var services = Services.Concat(SelectedServices).OrderBy(x => x.Id).ToList();
            Services = new ObservableCollection<ServiceDto>(services);
            SelectedServices.Clear();
            RaisePropertiesChanged(nameof(Services), nameof(SelectedServices));
        }
    }

    private bool FilterClient(object obj)
    {
        var client = obj as ClientDto;

        if (string.IsNullOrWhiteSpace(SearchClientText))
            return true;

        var searchFields = new[]
        {
            client.LastName,
            client.FirstName,
            client.Surname,
            client.PhoneNumber,
            string.Join(' ', client.LastName, client.FirstName, client.Surname)
        };

        return searchFields
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Where(x => x.Contains(SearchClientText, StringComparison.OrdinalIgnoreCase))
            .Any();
    }
    private bool FilterBarber(object obj)
    {
        var barber = obj as BarberDto;

        if (string.IsNullOrWhiteSpace(SearchBarberText))
            return true;

        var searchFields = new[]
        {
            barber.LastName,
            barber.FirstName,
            barber.Surname,
            string.Join(' ', barber.LastName, barber.FirstName, barber.Surname)
        };

        return searchFields
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Where(x => x.Contains(SearchBarberText, StringComparison.OrdinalIgnoreCase))
            .Any();
    }

    private void SelectService()
    {
        var selectedServiceSkillLevel = ServiceDtoToServiceConverter.MapService(ServiceToSelect, SelectedBarber.SkillLevel);

        SelectedServices.Add(ServiceToSelect);
        Services.Remove(ServiceToSelect);

        TotalCost += selectedServiceSkillLevel.Cost;
        TotalMinutes += selectedServiceSkillLevel.MinutesDuration;
    }

    private void RemoveSelectedService()
    {
        var selectedServiceSkillLevel = ServiceDtoToServiceConverter.MapService(SelectedService, SelectedBarber.SkillLevel);

        Services.Add(SelectedService);
        SelectedServices.Remove(SelectedService);

        TotalCost -= selectedServiceSkillLevel.Cost;
        TotalMinutes -= selectedServiceSkillLevel.MinutesDuration;
    }

    private async Task FilterTimeSlots()
    {
        if (TimeSlots is null)
            return;

        SelectedTimeSlot = null;
        TimeSlots.ForEach(x => x.State = TimeSlotState.Open);

        var ordersAtDay = (await _orderService.GetBarberOrders(SelectedBarber.Id, SelectedDate.Value))
            .OrderBy(x => x.BeginDateTime)
            .ToList();

        if (ordersAtDay.Any())
        {
            for (int i = 0, currentOrder = 0; i < TimeSlots.Count && currentOrder < ordersAtDay.Count; i++)
            {
                var order = ordersAtDay[currentOrder];

                if (TimeOnly.FromDateTime(order.BeginDateTime) == TimeSlots[i].Time)
                {
                    var servicesDuration = order.Services.Sum(x => x.MinutesDuration);

                    var coefficient = (int)Math.Round(servicesDuration / 30.0, MidpointRounding.ToPositiveInfinity);

                    if (coefficient == 1)
                    {
                        TimeSlots[i].State = TimeSlotState.Busy;
                    }
                    else
                    {
                        for (int j = i, count = 0; count < coefficient; j++, count++)
                        {
                            TimeSlots[j].State = TimeSlotState.Busy;
                        }

                        i += coefficient;
                    }

                    currentOrder++;
                }
            }
        }

        var selectedServicesCoefficient = (int)Math.Round(TotalMinutes / 30.0, MidpointRounding.ToPositiveInfinity);

        for (int i = 0; i < TimeSlots.Count; i++)
        {
            if (TimeSlots[i].State == TimeSlotState.Open)
            {
                if (selectedServicesCoefficient == 1)
                {
                    TimeSlots[i].State = TimeSlotState.Open;
                    continue;
                }
                else
                {
                    var potentialSlots = TimeSlots.Skip(i).TakeWhile(x => x.State == TimeSlotState.Open).ToList();

                    for (int j = 0; j < potentialSlots.Count; j++)
                    {
                        if (selectedServicesCoefficient <= potentialSlots.Count - j)
                        {
                            potentialSlots[j].State = TimeSlotState.Open;
                        }
                        else
                        {
                            potentialSlots[j].State = TimeSlotState.NotAllowed;
                        }
                    }

                    i += potentialSlots.Count;
                }
            }
        }
    }

    private void SelectTimeSlot(RoutedEventArgs eventArgs)
    {
        SelectedTimeSlot = (eventArgs.Source as RadioButton).DataContext as TimeSlot;
    }

    private void CreateOrder()
    {
        SelectedDate = new DateTime(SelectedDate.Value.Year, SelectedDate.Value.Month, SelectedDate.Value.Day, SelectedTimeSlot.Time.Hour, SelectedTimeSlot.Time.Minute, 0);
        OnOrderCreateCall?.Invoke();
    }
}

public class TimeSlot : BindableBase
{
    public TimeOnly Time { get; set; }

    public TimeSlotState State
    {
        get => GetValue<TimeSlotState>(nameof(State));
        set => SetValue(value, nameof(State));
    }

    public TimeSlot(TimeOnly time)
    {
        Time = time;
    }

    public override string ToString()
        => Time.ToString();
}

public enum TimeSlotState
{
    Open,
    NotAllowed,
    Busy
}