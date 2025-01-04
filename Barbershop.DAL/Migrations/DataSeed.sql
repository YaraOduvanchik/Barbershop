--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.0

-- Started on 2024-04-06 02:41:44

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;


--
-- TOC entry 4927 (class 0 OID 391537)
-- Dependencies: 223
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (1, 'Александров', 'Антон', 'Валентинович', 'anton17091992@hotmail.com', '+7 (984) 220-56-38', NULL, '1992-09-17 00:00:00+04');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (2, 'Ермолин', 'Валерий', 'Захарович', 'valeriy22091996@yandex.ru', '+7 (906) 483-87-22', NULL, '1996-09-22 00:00:00+04');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (3, 'Жестакова', 'Тимофей', 'Семенович', 'timofey1972@gmail.com', '+7 (951) 614-65-70', NULL, '1972-07-04 00:00:00+03');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (4, 'Курбатов', 'Илья', 'Игнатьевич', 'ilya14081993@outlook.com', '+7 (924) 451-12-78', NULL, '1993-08-14 00:00:00+04');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (5, 'Меркулов', 'Василий', 'Васильевич', 'vasiliy9663@hotmail.com', '+7 (931) 319-75-46', NULL, '1996-03-19 00:00:00+03');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (6, 'Грехов', 'Грехов', 'Семенович', 'adam8291@hotmail.com', '+7 (906) 184-94-80', NULL, '1981-08-19 00:00:00+04');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (7, 'Кузьмин', 'Никита', 'Савванович', 'nikita.kuzmin@mail.ru', '+7 (937) 546-67-88', NULL, '1977-10-03 00:00:00+03');
INSERT INTO public."User" ("Id", "LastName", "FirstName", "Surname", "Email", "PhoneNumber", "Photo", "Birthday") VALUES (8, 'Копориков', 'Даниил', 'Григорьевич', 'daniil.koporikov@hotmail.com', '+7 (921) 899-13-90', NULL, '1974-01-26 00:00:00+03');


--
-- TOC entry 4930 (class 0 OID 391557)
-- Dependencies: 226
-- Data for Name: Admin; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Admin" ("Id", "Login", "PasswordHash") VALUES (1, 'admin', 'x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A==');


--
-- TOC entry 4931 (class 0 OID 391569)
-- Dependencies: 227
-- Data for Name: Barber; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Barber" ("Id", "Login", "PasswordHash", "SkillLevel") VALUES (3, 'user2', 'KREWd1kCs43QlYetYjXOxQP8FNv5wJytdh8uWldVEC6s61S5X/0XnCJlLDkQ28bthd3efgnu8ezzrSGSJfUJ9Q==', 'Middle');
INSERT INTO public."Barber" ("Id", "Login", "PasswordHash", "SkillLevel") VALUES (2, 'user1', 'nsYsIBGP9QbawTnsMKUh0SuYg+VdqSt9mt7v4J7U4L0VLioJkzmHFCQmN4T4EDOR+Dt4HEMvRezLA+GOKAYNLw==', 'Junior');
INSERT INTO public."Barber" ("Id", "Login", "PasswordHash", "SkillLevel") VALUES (4, 'user3', 'user3', 'Senior');


--
-- TOC entry 4921 (class 0 OID 391515)
-- Dependencies: 217
-- Data for Name: BarbershopParameterRows; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4932 (class 0 OID 391581)
-- Dependencies: 228
-- Data for Name: Client; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Client" ("Id", "Notes") VALUES (8, NULL);
INSERT INTO public."Client" ("Id", "Notes") VALUES (7, NULL);
INSERT INTO public."Client" ("Id", "Notes") VALUES (6, NULL);
INSERT INTO public."Client" ("Id", "Notes") VALUES (5, NULL);


--
-- TOC entry 4934 (class 0 OID 391594)
-- Dependencies: 230
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (4, 'Created', '2024-04-08 09:00:00+03', NULL, 15, 2, 5);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (5, 'Created', '2024-04-08 11:30:00+03', NULL, 25, 3, 6);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (6, 'Created', '2024-04-08 13:00:00+03', NULL, 35, 4, 7);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (7, 'Created', '2024-04-09 15:00:00+03', NULL, 25, 3, 7);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (8, 'Created', '2024-04-10 17:00:00+03', NULL, 35, 4, 8);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (9, 'Created', '2024-04-10 12:30:00+03', NULL, 25, 3, 7);
INSERT INTO public."Order" ("Id", "OrderStatus", "CreatedOn", "CompletedOn", "BarbersGain", "BarberId", "ClientId") VALUES (10, 'Created', '2024-04-11 19:00:00+03', NULL, 35, 4, 8);


--
-- TOC entry 4923 (class 0 OID 391521)
-- Dependencies: 219
-- Data for Name: Product; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (1, 'Кондиционер для волос', 1041);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (2, 'Шампунь мужской', 1020);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (3, 'Лосьон для волос', 789);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (4, 'Помада для укладки', 1463);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (5, 'Бальзам после бритья', 383);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (6, 'Масло для бороды', 639);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (7, 'Спрей для волос с морской солью', 1359);
INSERT INTO public."Product" ("Id", "Name", "Cost") VALUES (8, 'Гель для бритья', 508);


--
-- TOC entry 4935 (class 0 OID 391611)
-- Dependencies: 231
-- Data for Name: OrderProduct; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."OrderProduct" ("OrdersId", "ProductsId") VALUES (5, 2);
INSERT INTO public."OrderProduct" ("OrdersId", "ProductsId") VALUES (5, 5);
INSERT INTO public."OrderProduct" ("OrdersId", "ProductsId") VALUES (5, 6);


--
-- TOC entry 4925 (class 0 OID 391529)
-- Dependencies: 221
-- Data for Name: Service; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Service" ("Id", "Name") VALUES (1, 'Мужская стрижка');
INSERT INTO public."Service" ("Id", "Name") VALUES (2, 'Моделирование бороды');
INSERT INTO public."Service" ("Id", "Name") VALUES (3, 'Тонирование бороды');
INSERT INTO public."Service" ("Id", "Name") VALUES (4, 'Окантовка');
INSERT INTO public."Service" ("Id", "Name") VALUES (5, 'Тонирование головы');
INSERT INTO public."Service" ("Id", "Name") VALUES (6, 'Стрижка машинкой');
INSERT INTO public."Service" ("Id", "Name") VALUES (7, 'Традиционное бритье');



--
-- TOC entry 4929 (class 0 OID 391545)
-- Dependencies: 225
-- Data for Name: ServiceSkillLevel; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (1, 'Junior', 600, 45, 1);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (2, 'Middle', 700, 45, 1);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (3, 'Senior', 800, 45, 1);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (4, 'Junior', 500, 30, 2);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (5, 'Middle', 550, 30, 2);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (6, 'Senior', 650, 30, 2);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (7, 'Junior', 250, 15, 3);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (8, 'Middle', 350, 15, 3);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (9, 'Senior', 450, 15, 3);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (10, 'Junior', 200, 10, 4);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (11, 'Middle', 200, 10, 4);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (12, 'Senior', 200, 10, 4);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (13, 'Junior', 1000, 60, 5);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (14, 'Middle', 1200, 60, 5);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (15, 'Senior', 1500, 60, 5);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (16, 'Junior', 500, 30, 6);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (17, 'Middle', 520, 30, 6);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (18, 'Senior', 600, 30, 6);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (19, 'Junior', 800, 30, 7);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (20, 'Middle', 900, 30, 7);
INSERT INTO public."ServiceSkillLevel" ("Id", "SkillLevel", "Cost", "MinutesDuration", "ServiceId") VALUES (21, 'Senior', 1000, 30, 7);


--
-- TOC entry 4936 (class 0 OID 391626)
-- Dependencies: 232
-- Data for Name: OrderServiceSkillLevel; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (4, 1);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (4, 3);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (5, 2);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (5, 4);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (6, 1);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (6, 7);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (7, 1);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (7, 2);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (8, 5);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (8, 6);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (8, 7);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (9, 4);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (9, 5);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (10, 6);
INSERT INTO public."OrderServiceSkillLevel" ("OrdersId", "ServiceSkillLevelsId") VALUES (10, 7);


--
-- TOC entry 4942 (class 0 OID 0)
-- Dependencies: 216
-- Name: BarbershopParameterRows_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BarbershopParameterRows_Id_seq"', 1, false);


--
-- TOC entry 4943 (class 0 OID 0)
-- Dependencies: 229
-- Name: Order_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Order_Id_seq"', 10, true);


--
-- TOC entry 4944 (class 0 OID 0)
-- Dependencies: 218
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Product_Id_seq"', 8, true);


--
-- TOC entry 4945 (class 0 OID 0)
-- Dependencies: 224
-- Name: ServiceSkillLevel_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ServiceSkillLevel_Id_seq"', 21, true);


--
-- TOC entry 4946 (class 0 OID 0)
-- Dependencies: 220
-- Name: Service_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Service_Id_seq"', 7, true);


--
-- TOC entry 4947 (class 0 OID 0)
-- Dependencies: 222
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_Id_seq"', 8, true);


-- Completed on 2024-04-06 02:41:45

--
-- PostgreSQL database dump complete
--

