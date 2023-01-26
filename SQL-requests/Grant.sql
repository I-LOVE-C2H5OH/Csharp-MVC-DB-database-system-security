GRANT Insert on client TO bot;
GRANT Insert on Tour TO bot;
GRANT Insert on Contract TO bot;
GRANT Insert on GroupComposition TO bot;
GRANT Insert on Excursion TO bot;
GRANT Insert on ExcursionComposition TO bot;

GRANT SELECT on allContractInfo TO bot;
GRANT SELECT on allclienttoInfo TO bot;
GRANT SELECT on Tour TO bot;
GRANT SELECT on Contract TO bot;
GRANT SELECT on GroupComposition TO bot;
GRANT SELECT on Excursion TO bot;
GRANT SELECT on ExcursionComposition TO bot;

GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO bot;

GRANT EXECUTE ON PROCEDURE addnewclient TO bot;
GRANT EXECUTE ON PROCEDURE addnewTour TO bot;
GRANT EXECUTE ON PROCEDURE addnewContract TO bot;
GRANT EXECUTE ON PROCEDURE addnewGroupComposition TO bot;
GRANT EXECUTE ON PROCEDURE addnewExcursion TO bot;
GRANT EXECUTE ON PROCEDURE addnewExcursionComposition TO bot;






ALTER TABLE client ENABLE ROW LEVEL SECURITY;

CREATE POLICY select_all_servers
    ON client FOR SELECT
    USING (true);