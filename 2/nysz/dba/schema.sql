create table User (
    UserName text,
    UserPassword text
);

create table Session (
    SessionID text,
    CreationTime INTEGER,
    UserName
);

INSERT INTO User (UserName, UserPassword)
values 
('alma', 'alma'),
('kocka', 'kor'),
('john', 'doe'),
('bala', 'lajka');