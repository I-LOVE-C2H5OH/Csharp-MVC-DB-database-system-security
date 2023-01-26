call addNewClient('John', 'Doe', '+123456789', 'jon@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYS');
call addNewClient('Joh', 'Doe', '+123456789', 'joh@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXss');
call addNewClient('Jo', 'Doe', '+123456789', 'john@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYR');
call addNewClient('John', 'Doe', '+123456789', 'john@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ');
call addNewClient('Jane', 'Doe', '+123456780', 'jane@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYA');
call addNewClient('Joe', 'Doe', '+123456781', 'joe@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYB');
call addNewClient('Mark', 'Doe', '+123456782', 'mark@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYC');
call addNewClient('Mary', 'Doe', '+123456783', 'mary@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYD');


call addNewClient('Mars', 'Dos', '+12345678', 'mary@example.com', 'ABCDEFGHIJKLMNOPQRSTUVW');

--------------------------------------------------------------------------------------------------

call addNewTour('Australia', 14, 2500);
call addNewTour('India', 7, 500);
call addNewTour('USA', 21, 4000);
call addNewTour('Russia', 10, 1000);
call addNewTour('Spain', 5, 2000);

call addNewTour('Spai', 6, 2000);

--------------------------------------------------------------------------------------------------

call addNewContract(1, '2023-06-01');
call addNewContract(2, '2023-07-01');
call addNewContract(3, '2023-08-01');
call addNewContract(4, '2023-09-01');
call addNewContract(5, '2023-10-01');

call addNewContract(6, '2023-11-01');

--------------------------------------------------------------------------------------------------

call addNewGroupComposition(1, 1);
call addNewGroupComposition(1, 2);
call addNewGroupComposition(1, 3);
call addNewGroupComposition(2, 4);
call addNewGroupComposition(3, 5);
call addNewGroupComposition(4, 6);
call addNewGroupComposition(5, 7);

--------------------------------------------------------------------------------------------------

call addNewExcursion(1, 'Sydney Opera House', '10:00-12:00');
call addNewExcursion(1, 'Sydney Opera House', '12:30-14:30');
call addNewExcursion(1, 'Sydney Opera House', '14:40-18:30');
call addNewExcursion(2, 'Taj Mahal', '14:00-16:00');
call addNewExcursion(3, 'Grand Canyon', '09:00-11:00');
call addNewExcursion(4, 'Red Square', '19:00-21:00');
call addNewExcursion(5, 'Sagrada Familia', '10:00-12:00');

--------------------------------------------------------------------------------------------------

call addNewExcursionComposition(1, 1, '2023-06-06');
call addNewExcursionComposition(1, 2, '2023-06-06');
call addNewExcursionComposition(1, 3, '2023-06-06');
call addNewExcursionComposition(2, 4, '2023-07-06');
call addNewExcursionComposition(3, 5, '2023-08-06');
call addNewExcursionComposition(4, 6, '2023-09-06');
call addNewExcursionComposition(5, 7, '2023-10-06');