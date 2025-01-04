using Barbershop.Contracts.Models;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Barbershop.Services.Services;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class SalaryPageViewModel : BaseViewModel
{
    private readonly OrderService _orderService;

    private IReadOnlyList<OrderDto> _orders;

    public ObservableCollection<OrderDto> Orders
    {
        get => GetValue<ObservableCollection<OrderDto>>(nameof(Orders));
        set => SetValue(value, () => RaisePropertiesChanged(nameof(TotalCost), nameof(TotalMinutes)), nameof(Orders));
    }

    public decimal TotalCost => Orders?.Sum(x => x.PureCost) ?? 0;
    public int TotalMinutes => Orders?.Sum(x => x.TotalMinutes) ?? 0;

    public bool WithoutDateSelected
    {
        get => GetValue<bool>(nameof(WithoutDateSelected));
        set => SetValue(value, ResetDateInterval, nameof(WithoutDateSelected));
    }
    public bool TodayFilterSelected
    {
        get => GetValue<bool>(nameof(TodayFilterSelected));
        set => SetValue(value, ResetDateInterval, nameof(TodayFilterSelected));
    }
    public bool Last30Days
    {
        get => GetValue<bool>(nameof(Last30Days));
        set => SetValue(value, ResetDateInterval, nameof(Last30Days));
    }
    public bool CurrentMonth
    {
        get => GetValue<bool>(nameof(CurrentMonth));
        set => SetValue(value, ResetDateInterval, nameof(CurrentMonth));
    }
    public DateTime? FromDateSelected
    {
        get => GetValue<DateTime?>(nameof(FromDateSelected));
        set => SetValue(value, ResetHardcodeDateRange, nameof(FromDateSelected));
    }
    public DateTime? ToDateSelected
    {
        get => GetValue<DateTime?>(nameof(ToDateSelected));
        set => SetValue(value, ResetHardcodeDateRange, nameof(ToDateSelected));
    }

    public ICommand ClearFilterCommand { get; }
    public ICommand FilterOrdersCommand { get; }

    public SalaryPageViewModel(OrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

        LoadViewDataCommand = new AsyncCommand(LoadView);

        ClearFilterCommand = new DelegateCommand(ClearFilter);
        FilterOrdersCommand = new DelegateCommand(FilterOrders);

        WithoutDateSelected = true;
    }

    public async Task LoadView()
    {
        await Execute(async () =>
        {
            _orders = await _orderService.GetAll();
            _orders = _orders
                .Where(x => x.Barber.Id == App.CurrentUser.Id)
                .Where(x => x.Status == OrderStatusDto.Done)
                .OrderByDescending(x => x.BeginDateTime)
                .ToList();

            Orders = new ObservableCollection<OrderDto>(_orders);
            RaisePropertiesChanged(nameof(TotalCost), nameof(TotalMinutes));
        });
    }

    private void ResetHardcodeDateRange()
    {
        WithoutDateSelected = TodayFilterSelected = false;
        Last30Days = CurrentMonth = false;
    }

    private void ResetDateInterval(bool isTrue)
    {
        if (isTrue)
            FromDateSelected = ToDateSelected = null;
    }

    private void FilterOrders()
    {
        var orders = _orders.Select(x => x);
        var currentDate = DateTime.Now.Date;

        if (TodayFilterSelected)
            orders = orders.Where(x => x.BeginDateTime.Date == currentDate);

        if (Last30Days)
            orders = orders.Where(x => x.BeginDateTime.Date >= currentDate.AddDays(-30) && x.BeginDateTime.Date <= currentDate);

        if (CurrentMonth)
        {
            orders = orders.Where(x => x.BeginDateTime.Year == currentDate.Year && x.BeginDateTime.Month == currentDate.Month);
        }

        if (FromDateSelected != null && ToDateSelected != null)
        {
            orders = orders.Where(x => x.BeginDateTime.Date >= FromDateSelected.Value.Date && x.BeginDateTime.Date <= ToDateSelected.Value.Date);
        }

        if (FromDateSelected != null)
        {
            orders = orders.Where(x => x.BeginDateTime.Date >= FromDateSelected.Value.Date);
        }

        if (ToDateSelected != null)
        {
            orders = orders.Where(x => x.BeginDateTime.Date <= ToDateSelected.Value.Date);
        }

        Orders = new ObservableCollection<OrderDto>(orders);
        RaisePropertiesChanged(nameof(TotalCost), nameof(TotalMinutes));
    }

    private void ClearFilter()
    {
        WithoutDateSelected = true;

        TodayFilterSelected = Last30Days = CurrentMonth = false;

        Orders = new ObservableCollection<OrderDto>(_orders);
        RaisePropertiesChanged(nameof(TotalCost), nameof(TotalMinutes));
    }
}
