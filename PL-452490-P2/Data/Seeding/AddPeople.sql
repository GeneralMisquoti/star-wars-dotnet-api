DELETE FROM "People";
INSERT INTO "People" ("Id", "Name", "MidichlorianCount")
VALUES
    -- https://starwars.fandom.com/wiki/Qui-Gon_Jinn
    (0, 'Qui-Gon Jinn', 10000), -- Dooku
    -- https://starwars.fandom.com/wiki/Darth_Sidious https://en.wikipedia.org/wiki/Palpatine
    (1, 'Sheev Palpatine', 20500),
    -- https://starwars.fandom.com/wiki/Anakin_Skywalker https://en.wikipedia.org/wiki/Darth_Vader
    (2, 'Anakin Skywalker', 27700),
    -- https://starwars.fandom.com/wiki/Obi-Wan_Kenobi https://en.wikipedia.org/wiki/Obi-Wan_Kenobi
    (3, 'Obi-Wan Kenobi', 13400),
    -- https://starwars.fandom.com/wiki/Dooku https://en.wikipedia.org/wiki/Count_Dooku
    (4, 'Dooku', 13500),
    -- https://starwars.fandom.com/wiki/Maul https://en.wikipedia.org/wiki/Darth_Maul
    (5, 'Maul', 12000),
    -- https://starwars.fandom.com/wiki/Padm%C3%A9_Amidala
    (6, N'Padmé Amidala', 4700),
    -- https://starwars.fandom.com/wiki/Yoda https://en.wikipedia.org/wiki/Yoda
    (7, 'Yoda', 17700),
    -- https://starwars.fandom.com/wiki/Mace_Windu https://en.wikipedia.org/wiki/Mace_Windu
    (8, 'Mace Windu', 12000),
    -- https://starwars.fandom.com/wiki/Grievous https://en.wikipedia.org/wiki/General_Grievous
    (9, 'General Grievous', 11900) -- not a sith