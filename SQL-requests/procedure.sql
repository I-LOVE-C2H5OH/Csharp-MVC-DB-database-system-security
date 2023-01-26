CREATE PROCEDURE addNewClient(firstname VARCHAR(50), lastname VARCHAR(50), phon VARCHAR(15), emai VARCHAR(100), passpor VARCHAR(100))
LANGUAGE SQL
AS $$
INSERT INTO Client (first_name, last_name, phone, email, passport)
VALUES (firstname, lastname, phon, emai, passpor);
$$;

CREATE PROCEDURE addNewTour(name VARCHAR(100), duration INTEGER, costs INTEGER)
LANGUAGE SQL
AS $$
INSERT INTO Tour (tour_name, tour_duration, cost) VALUES
(name, duration, costs);
$$;


-- Необходима для получения длительности Тура по его ID;
CREATE OR REPLACE FUNCTION get_tourduration(tour_id integer) RETURNS int
AS $$
#print_strict_params on
DECLARE
userid int;
BEGIN
    SELECT Tour.tour_duration INTO STRICT userid
        FROM Tour WHERE Tour.tour_id = get_tourduration.tour_id;
    RETURN userid;
END;
$$ LANGUAGE plpgsql;



CREATE PROCEDURE addNewContract(tour_id INTEGER, dateofissue DATE)
LANGUAGE SQL
AS $$

INSERT INTO Contract (tour_id, date_of_issue, date_of_signing) VALUES
(tour_id, dateofissue, dateofissue + get_tourduration(tour_id));
$$;

CREATE PROCEDURE addNewBoundle(contractid INTEGER, clientid INTEGER)
LANGUAGE SQL
AS $$
INSERT INTO boundle (contract_id, client_id) VALUES
(contractid, clientid);
$$

CREATE PROCEDURE addNewExcursion(tourid INTEGER, name VARCHAR(100), shedule VARCHAR(15))
LANGUAGE SQL
AS $$
INSERT INTO Excursion (tour_id, excursion_name, excursion_shedule)
VALUES (tourid, name, shedule);
$$

CREATE PROCEDURE addNewExcursionComposition(contractid INTEGER, excursionid INTEGER, excursuindate DATE)
LANGUAGE SQL
AS $$
INSERT INTO ExcursionComposition (contract_id, excursion_id, excursuin_date) VALUES
(contractid, excursionid, excursuindate);
$$

