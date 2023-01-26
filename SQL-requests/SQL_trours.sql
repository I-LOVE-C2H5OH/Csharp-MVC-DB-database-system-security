CREATE TABLE Client (
  client_id serial PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  phone VARCHAR(15) NOT NULL,
  email VARCHAR(100) NOT NULL,
  passport VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Tour (
  tour_id serial PRIMARY KEY,
  tour_name VARCHAR(100) NOT NULL,
  tour_duration INTEGER NOT NULL,
  cost INTEGER NOT NULL
);

CREATE TABLE Contract (
  contract_id serial PRIMARY KEY,
  --client_id INTEGER REFERENCES Client(client_id),
  tour_id INTEGER REFERENCES Tour(tour_id),
  date_of_issue DATE NOT NULL,
  date_of_signing DATE NOT NULL
);

CREATE TABLE boundle (
  composition_id serial PRIMARY KEY,
  contract_id INTEGER REFERENCES Contract(contract_id),
  client_id INTEGER REFERENCES Client(client_id)
);

CREATE TABLE Excursion (
  excursion_id serial PRIMARY KEY,
  tour_id INTEGER REFERENCES Tour(tour_id),
  excursion_name VARCHAR(100) NOT NULL
  --cost INTEGER NOT NULL
);

CREATE TABLE ExcursionShedule (
  sheduleID serial PRIMARY KEY,
  excursion_id INTEGER REFERENCES Excursion(excursion_id),
  dayweek varchar(25) NOT NULL,
);