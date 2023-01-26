INSERT INTO Client (first_name, last_name, phone, email, passport) VALUES
('Ralph', 'Adams', '+380661234567', 'ralph.adams@gmail.com', 'AK2456789'),
('Jack', 'Smith', '+380997654321', 'jack.smith@gmail.com', 'KL5678125'),
('Josh', 'Davis', '+380937654321', 'josh.davis@gmail.com', 'KP3456789'),
('Michael', 'Wilson', '+380671234567', 'michael.wilson@gmail.com', 'QT89012234'),
('Robert', 'Johnson', '+380661234567', 'robert.johnson@gmail.com', 'KL5678123'),
('David', 'Williams', '+380998765432', 'david.williams@gmail.com', 'PO3456781'),
('John', 'Jones', '+380937876543', 'john.jones@gmail.com', 'QT890122234'),
('Mark', 'Brown', '+380671234567', 'mark.brown@gmail.com', 'AL5678120'),
('Paul', 'Miller', '+380998765432', 'paul.miller@gmail.com', 'PO3456780'),
('David', 'Wilson', '+380937876543', 'david.wilson@gmail.com', 'QT8901231'),
('Christopher', 'Moore', '+380671234567', 'christopher.moore@gmail.com', 'AL5678121'),
('John', 'Taylor', '+380998765432', 'john.taylor@gmail.com', 'PO345678900'),
('Daniel', 'Anderson', '+380937876543', 'daniel.anderson@gmail.com', 'QT8901234'),
('Anthony', 'Thomas', '+380671234567', 'anthony.thomas@gmail.com', 'AL5678123'),
('Brian', 'Jackson', '+380998765432', 'brian.jackson@gmail.com', 'PO3456789');

INSERT INTO Tour (tour_name, tour_duration, cost) VALUES
('Budapest-Vienna-Prague', 10, 2000),
('France-Italy-Greece', 14, 2500),
('Spain-Portugal-Morocco', 12, 3000),
('Norway-Sweden-Finland', 11, 2500),
('Croatia-Montenegro-Albania', 8, 2400),
('Scotland-Ireland-England', 12, 2200),
('Sicily-Sardinia-Corsica', 9, 2800),
('Switzerland-Austria-Germany', 10, 2700),
('Hungary-Slovakia-Ukraine', 8, 2000),
('France-Belgium-Netherlands', 9, 2500),
('Greece-Turkey-Cyprus', 11, 3000),
('Iceland-Greenland-Faroe Islands', 14, 2400),
('Denmark-Norway-Sweden', 12, 2200),
('Malta-Sicily-Greece', 9, 2800),
('Switzerland-Italy-Slovenia', 10, 2700);

INSERT INTO Contract (tour_id, date_of_issue, date_of_signing) VALUES
(1, '2020-01-01', '2020-01-05'),
(2, '2020-01-06', '2020-01-10'),
(3, '2020-01-11', '2020-01-15'),
(4, '2020-01-16', '2020-01-20'),
(5, '2020-01-21', '2020-01-25'),
(6, '2020-01-26', '2020-01-30'),
(7, '2020-02-01', '2020-02-05'),
(8, '2020-02-06', '2020-02-10'),
(9, '2020-02-11', '2020-02-15'),
(10, '2020-02-16', '2020-02-20'),
(11, '2020-02-21', '2020-02-25'),
(12, '2020-02-26', '2020-03-01'),
(13, '2020-03-02', '2020-03-06'),
(14, '2020-03-07', '2020-03-11'),
(15, '2020-03-12', '2020-03-16');

INSERT INTO boundle (contract_id, client_id) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15);

INSERT INTO Excursion (tour_id, excursion_name, excursion_shedule) VALUES
(1, 'Night Tour of Budapest', 'daily'),
(2, 'Eiffel Tower Visit', 'daily'),
(3, 'Gaudi Tour', 'daily'),
(4, 'The Northern Lights', 'daily'),
(5, 'Kotor Bay Cruise', 'daily'),
(6, 'Edinburgh Castle Tour', 'daily'),
(7, 'Island Hopping Tour', 'daily'),
(8, 'Mozart Tour', 'daily'),
(9, 'The Danube Banks', 'daily'),
(10, 'Paris by Night', 'daily'),
(11, 'Santorini Sunset Tour', 'daily'),
(12, 'The Fjords Tour', 'daily'),
(13, 'Tivoli Gardens Tour', 'daily'),
(14, 'Malta Sailing Tour', 'daily'),
(15, 'The Swiss Alps Tour', 'daily');

INSERT INTO ExcursionShedule (excursion_id, dayweek) VALUES
(1, 'Monday'),
(1, 'Tuesday'),
(1, 'Wednesday'),
(1, 'Thursday'),
(1, 'Friday'),
(1, 'Saturday'),
(1, 'Sunday'),
(2, 'Monday'),
(2, 'Tuesday'),
(2, 'Wednesday'),
(2, 'Thursday'),
(2, 'Friday'),
(2, 'Saturday'),
(2, 'Sunday'),
(3, 'Monday'),
(3, 'Tuesday'),
(3, 'Wednesday'),
(3, 'Thursday'),
(3, 'Friday'),
(3, 'Saturday'),
(3, 'Sunday'),
(4, 'Monday'),
(4, 'Tuesday'),
(4, 'Wednesday'),
(4, 'Thursday'),
(4, 'Friday'),
(4, 'Saturday'),
(4, 'Sunday'),
(5, 'Monday'),
(5, 'Tuesday'),
(5, 'Wednesday'),
(5, 'Thursday'),
(5, 'Friday'),
(5, 'Saturday'),
(5, 'Sunday'),
(6, 'Monday'),
(6, 'Tuesday'),
(6, 'Wednesday'),
(6, 'Thursday'),
(6, 'Friday'),
(6, 'Saturday'),
(6, 'Sunday'),
(7, 'Monday'),
(7, 'Tuesday'),
(7, 'Wednesday'),
(7, 'Thursday'),
(7, 'Friday'),
(7, 'Saturday'),
(7, 'Sunday'),
(8, 'Monday'),
(8, 'Tuesday'),
(8, 'Wednesday'),
(8, 'Thursday'),
(8, 'Friday'),
(8, 'Saturday'),
(8, 'Sunday'),
(9, 'Monday'),
(9, 'Tuesday'),
(9, 'Wednesday'),
(9, 'Thursday'),
(9, 'Friday'),
(9, 'Saturday'),
(9, 'Sunday'),
(10, 'Monday'),
(10, 'Tuesday'),
(10, 'Wednesday'),
(10, 'Thursday'),
(10, 'Friday'),
(10, 'Saturday'),
(10, 'Sunday'),
(11, 'Monday'),
(11, 'Tuesday'),
(11, 'Wednesday'),
(11, 'Thursday'),
(11, 'Friday'),
(11, 'Saturday'),
(11, 'Sunday'),
(12, 'Monday'),
(12, 'Tuesday'),
(12, 'Wednesday'),
(12, 'Thursday'),
(12, 'Friday'),
(12, 'Saturday'),
(12, 'Sunday');