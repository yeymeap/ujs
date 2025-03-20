
CREATE TABLE tanar (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nev TEXT NOT NULL,
    szak TEXT NOT NULL,
    fizetes INTEGER NOT NULL,
    tapasztalat INTEGER NOT NULL,
    lakcim TEXT NOT NULL
);

INSERT INTO tanar (nev, szak, fizetes, tapasztalat, lakcim) VALUES
('Kovács Péter', 'matematika', 450000, 12, 'Budapest, Kossuth utca 12.'),
('Nagy Anna', 'fizika', 470000, 15, 'Szeged, Petőfi tér 5.'),
('Szabó László', 'kémia', 430000, 10, 'Debrecen, Dózsa György út 8.'),
('Tóth Mária', 'biológia', 440000, 8, 'Pécs, Rákóczi utca 23.'),
('Horváth Zoltán', 'magyar', 420000, 20, 'Győr, Szent István út 45.'),
('Varga Katalin', 'történelem', 460000, 18, 'Miskolc, Ady Endre utca 3.'),
('Kiss Tamás', 'angol', 480000, 22, 'Eger, Hunyadi út 14.'),
('Molnár Judit', 'német', 440000, 9, 'Székesfehérvár, Bartók Béla tér 7.'),
('Balogh Ferenc', 'informatika', 500000, 25, 'Békéscsaba, Deák Ferenc utca 11.'),
('Farkas Éva', 'testnevelés', 400000, 7, 'Sopron, Kölcsey Ferenc tér 9.');


CREATE TABLE tanulo (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nev TEXT NOT NULL,
    osztondij INTEGER NOT NULL,
    lakcim TEXT NOT NULL
);

INSERT INTO tanulo (nev, osztondij, lakcim) VALUES
('Kiss Gergő', 30000, 'Budapest, Rózsa utca 10.'),
('Szabó Eszter', 25000, 'Debrecen, Fő tér 5.'),
('Nagy Bence', 20000, 'Szeged, Bartók Béla út 8.'),
('Varga Lilla', 35000, 'Pécs, Táncsics Mihály utca 12.'),
('Tóth Márk', 27000, 'Győr, Arany János utca 7.'),
('Molnár Dóra', 22000, 'Miskolc, Kossuth Lajos tér 3.'),
('Balogh Zoltán', 40000, 'Eger, Ady Endre utca 11.'),
('Farkas Nóra', 29000, 'Székesfehérvár, Petőfi tér 14.'),
('Kovács Levente', 31000, 'Békéscsaba, Hunyadi út 9.'),
('Horváth Petra', 26000, 'Sopron, Deák tér 6.'),
('Lukács Ádám', 33000, 'Tatabánya, Jókai Mór utca 5.'),
('Papp Zsófia', 28000, 'Nyíregyháza, Széchenyi tér 8.'),
('Kerekes Máté', 24000, 'Zalaegerszeg, Rákóczi Ferenc út 13.'),
('Sándor Emese', 37000, 'Szolnok, Kölcsey Ferenc tér 4.'),
('Nemes Gábor', 32000, 'Kecskemét, Vasvári Pál utca 15.');


CREATE TABLE tantargy (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    tantargyazonosito TEXT NOT NULL UNIQUE,
    nev TEXT NOT NULL,
    leiras TEXT NOT NULL,
    ora_szama INTEGER NOT NULL,
    kotelezo BOOLEAN NOT NULL
);

INSERT INTO tantargy (tantargyazonosito, nev, leiras, ora_szama, kotelezo) VALUES
('MAT101', 'Matematika', 'Algebra és geometria alapjai', 5, 1),
('FIZ102', 'Fizika', 'Mechanika, hőtan és elektromosság', 4, 1),
('KEM103', 'Kémia', 'Szervetlen és szerves kémia', 3, 1),
('BIO104', 'Biológia', 'Növény- és állattan, ökológia', 4, 1),
('MAG105', 'Magyar nyelv és irodalom', 'Nyelvtan és klasszikus irodalom', 5, 1),
('TOR106', 'Történelem', 'Magyar és világtörténelem', 4, 1),
('ANG107', 'Angol nyelv', 'Alapfokú és haladó nyelvoktatás', 3, 1),
('NEM108', 'Német nyelv', 'Alapfokú és haladó nyelvoktatás', 3, 0),
('INF109', 'Informatika', 'Programozás, hálózatok és szoftverek', 5, 1),
('TES110', 'Testnevelés', 'Sport, mozgáskoordináció fejlesztése', 2, 1);



CREATE TABLE tanit (
    tanar_id INTEGER NOT NULL,
    tantargyazonosito TEXT NOT NULL,
    FOREIGN KEY (tanar_id) REFERENCES tanar(id),
    FOREIGN KEY (tantargyazonosito) REFERENCES tantargy(tantargyazonosito),
    PRIMARY KEY (tanar_id, tantargyazonosito)
);

-- Tanár és tantárgy összerendelések
INSERT INTO tanit (tanar_id, tantargyazonosito) VALUES
(1, 'MAT101'),  -- Kovács Péter (1 tantárgy)
(2, 'FIZ102'),  -- Nagy Anna (1 tantárgy)
(3, 'KEM103'),  -- Szabó László (1 tantárgy)

(4, 'BIO104'),  -- Tóth Mária (2 tantárgy)
(4, 'ANG107'),

(5, 'MAG105'),  -- Horváth Zoltán (2 tantárgy)
(5, 'TOR106'),

(6, 'INF109'),  -- Varga Katalin (3 tantárgy)
(6, 'NEM108'),
(6, 'TES110'),

(7, 'TES110'),  -- Kiss Tamás (1 tantárgy)
(8, 'FOLD111'), -- Molnár Judit (1 tantárgy, földrajz)
(9, 'TOR106'),  -- Balogh Ferenc (1 tantárgy)
(10, 'MAG105'); -- Farkas Éva (1 tantárgy)

-- A 'Földrajz' (tantárgyazonosító: 'FOLD111') tantárgy senki által nem tanítottként hagyható el vagy beosztható



CREATE TABLE tanul (
    tanulo_id INTEGER NOT NULL,
    tantargyazonosito TEXT NOT NULL,
    FOREIGN KEY (tanulo_id) REFERENCES tanulo(id),
    FOREIGN KEY (tantargyazonosito) REFERENCES tantargy(tantargyazonosito),
    PRIMARY KEY (tanulo_id, tantargyazonosito)
);

-- Tanulók és tantárgyak összerendelése (minden diák legalább 3 tárgyat tanul, minden tárgyat tanul valaki)
INSERT INTO tanul (tanulo_id, tantargyazonosito) VALUES
(1, 'MAT101'), (1, 'FIZ102'), (1, 'INF109'),  -- Kiss Gergő
(2, 'MAG105'), (2, 'TOR106'), (2, 'BIO104'),  -- Szabó Eszter
(3, 'KEM103'), (3, 'FIZ102'), (3, 'INF109'),  -- Nagy Bence
(4, 'ANG107'), (4, 'NEM108'), (4, 'TES110'),  -- Varga Lilla
(5, 'TOR106'), (5, 'MAG105'), (5, 'BIO104'),  -- Tóth Márk
(6, 'FIZ102'), (6, 'MAT101'), (6, 'TES110'),  -- Molnár Dóra
(7, 'INF109'), (7, 'KEM103'), (7, 'TOR106'),  -- Balogh Zoltán
(8, 'MAG105'), (8, 'ANG107'), (8, 'TES110'),  -- Farkas Nóra
(9, 'NEM108'), (9, 'BIO104'), (9, 'INF109'),  -- Kovács Levente
(10, 'KEM103'), (10, 'FIZ102'), (10, 'TES110'),  -- Horváth Petra
(11, 'MAT101'), (11, 'ANG107'), (11, 'MAG105'),  -- Lukács Ádám
(12, 'TOR106'), (12, 'NEM108'), (12, 'BIO104'),  -- Papp Zsófia
(13, 'INF109'), (13, 'TES110'), (13, 'KEM103'),  -- Kerekes Máté
(14, 'MAG105'), (14, 'FIZ102'), (14, 'MAT101'),  -- Sándor Emese
(15, 'NEM108'), (15, 'TOR106'), (15, 'BIO104');  -- Nemes Gábor


CREATE TABLE vizsga (
    tanulo_id INTEGER NOT NULL,
    tantargyazonosito TEXT NOT NULL,
    datum DATE NOT NULL,
    jegy TEXT CHECK(jegy IN ('A', 'B', 'C', 'D', 'E', 'F')) NOT NULL,
    FOREIGN KEY (tanulo_id) REFERENCES tanulo(id),
    FOREIGN KEY (tantargyazonosito) REFERENCES tantargy(tantargyazonosito),
    PRIMARY KEY (tanulo_id, tantargyazonosito, datum)
);

-- Vizsgák létrehozása minden tanulónak minden tantárgyból
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (1, 'TES110', '2025-06-20', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (1, 'MAT101', '2025-06-05', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (1, 'MAT101', '2025-06-12', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (1, 'TOR106', '2025-06-15', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (2, 'KEM103', '2025-06-20', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (2, 'MAG105', '2025-06-05', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (2, 'MAT101', '2025-06-25', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (2, 'MAT101', '2025-07-02', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (3, 'NEM108', '2025-06-05', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (3, 'NEM108', '2025-06-12', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (3, 'MAT101', '2025-06-05', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (3, 'BIO104', '2025-06-15', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (3, 'BIO104', '2025-06-22', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (4, 'FIZ102', '2025-06-05', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (4, 'MAT101', '2025-06-05', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (4, 'TES110', '2025-06-20', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (4, 'TES110', '2025-06-27', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (5, 'TES110', '2025-06-05', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (5, 'KEM103', '2025-06-25', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (5, 'KEM103', '2025-07-02', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (5, 'ANG107', '2025-06-10', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (6, 'MAG105', '2025-06-25', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (6, 'NEM108', '2025-06-25', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (6, 'BIO104', '2025-06-05', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (6, 'BIO104', '2025-06-12', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (7, 'TES110', '2025-06-15', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (7, 'TES110', '2025-06-22', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (7, 'FIZ102', '2025-06-10', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (7, 'MAG105', '2025-06-10', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (8, 'KEM103', '2025-06-10', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (8, 'NEM108', '2025-06-15', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (8, 'NEM108', '2025-06-22', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (8, 'MAT101', '2025-06-05', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (9, 'INF109', '2025-06-25', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (9, 'TOR106', '2025-06-10', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (9, 'NEM108', '2025-06-10', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (10, 'ANG107', '2025-06-10', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (10, 'ANG107', '2025-06-17', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (10, 'MAT101', '2025-06-15', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (10, 'MAT101', '2025-06-22', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (10, 'FIZ102', '2025-06-20', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (11, 'KEM103', '2025-06-25', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (11, 'BIO104', '2025-06-15', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (11, 'TOR106', '2025-06-05', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (12, 'FIZ102', '2025-06-05', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (12, 'TES110', '2025-06-10', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (12, 'MAT101', '2025-06-05', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (13, 'TOR106', '2025-06-10', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (13, 'TES110', '2025-06-20', 'B');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (13, 'MAG105', '2025-06-15', 'A');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (14, 'FIZ102', '2025-06-10', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (14, 'FIZ102', '2025-06-17', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (14, 'MAT101', '2025-06-10', 'D');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (14, 'TES110', '2025-06-20', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (15, 'TES110', '2025-06-10', 'E');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (15, 'MAG105', '2025-06-25', 'F');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (15, 'MAG105', '2025-07-02', 'C');
INSERT INTO vizsga (tanulo_id, tantargyazonosito, datum, jegy) VALUES (15, 'TOR106', '2025-06-05', 'C');

