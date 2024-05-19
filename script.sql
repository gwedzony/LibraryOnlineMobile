create table Authors
(
    Id                      INTEGER not null
        constraint PK_Authors
            primary key autoincrement,
    Name                    TEXT    not null,
    Surname                 TEXT    not null,
    Description             TEXT    not null,
    PhotoUrl                TEXT,
    MobileBooksAuthorCardId INTEGER
);

create table Collections
(
    Id                            INTEGER not null
        constraint PK_Collections
            primary key autoincrement,
    CollectionName                TEXT    not null,
    CollectionImage               TEXT    not null,
    RandomCollectionsMobilePageId INTEGER
);

create table Genres
(
    Id   INTEGER not null
        constraint PK_Genres
            primary key autoincrement,
    Name TEXT    not null
);

create table Books
(
    Id          INTEGER not null
        constraint PK_Books
            primary key autoincrement,
    Title       TEXT    not null,
    Description TEXT    not null,
    Image       TEXT    not null,
    ReadCount   INTEGER not null,
    AddDateTime TEXT    not null,
    BookGenreId INTEGER not null
        constraint FK_Books_Genres_BookGenreId
            references Genres
            on delete cascade,
    AuthorId    INTEGER not null
        constraint FK_Books_Authors_AuthorId
            references Authors
            on delete cascade
);

create table BookCollection
(
    BooksId       INTEGER not null
        constraint FK_BookCollection_Books_BooksId
            references Books
            on delete cascade,
    CollectionsId INTEGER not null
        constraint FK_BookCollection_Collections_CollectionsId
            references Collections
            on delete cascade,
    constraint PK_BookCollection
        primary key (BooksId, CollectionsId)
);

create index IX_BookCollection_CollectionsId
    on BookCollection (CollectionsId);

create index IX_Books_AuthorId
    on Books (AuthorId);

create index IX_Books_BookGenreId
    on Books (BookGenreId);

create table DetailBookMobilePages
(
    Id     INTEGER not null
        constraint PK_DetailBookMobilePages
            primary key autoincrement,
    BookId INTEGER not null
        constraint FK_DetailBookMobilePages_Books_BookId
            references Books
            on delete cascade
);

create unique index IX_DetailBookMobilePages_BookId
    on DetailBookMobilePages (BookId);

create table LatestMobileBooksCard
(
    Id     INTEGER not null
        constraint PK_LatestMobileBooksCard
            primary key autoincrement,
    BookId INTEGER not null
        constraint FK_LatestMobileBooksCard_Books_BookId
            references Books
            on delete cascade
);

create unique index IX_LatestMobileBooksCard_BookId
    on LatestMobileBooksCard (BookId);

create table MobileBooksAuthorCard
(
    Id     INTEGER not null
        constraint PK_MobileBooksAuthorCard
            primary key autoincrement,
    BookId INTEGER not null
        constraint FK_MobileBooksAuthorCard_Authors_BookId
            references Authors
            on delete cascade
);

create unique index IX_MobileBooksAuthorCard_BookId
    on MobileBooksAuthorCard (BookId);

create table RandomMobileBooksCollectionCards
(
    Id           INTEGER not null
        constraint PK_RandomMobileBooksCollectionCards
            primary key autoincrement,
    CollectionId INTEGER not null
        constraint FK_RandomMobileBooksCollectionCards_Collections_CollectionId
            references Collections
            on delete cascade
);

create table BooksCollections
(
    Id                                INTEGER not null
        constraint PK_BooksCollections
            primary key autoincrement,
    BookId                            INTEGER not null
        constraint FK_BooksCollections_Books_BookId
            references Books
            on delete cascade,
    CollectionId                      INTEGER not null
        constraint FK_BooksCollections_Collections_CollectionId
            references Collections
            on delete cascade,
    RandomMobileBooksCollectionCardId INTEGER
        constraint FK_BooksCollections_RandomMobileBooksCollectionCards_RandomMobileBooksCollectionCardId
            references RandomMobileBooksCollectionCards
);

create index IX_BooksCollections_BookId
    on BooksCollections (BookId);

create index IX_BooksCollections_CollectionId
    on BooksCollections (CollectionId);

create index IX_BooksCollections_RandomMobileBooksCollectionCardId
    on BooksCollections (RandomMobileBooksCollectionCardId);

create unique index IX_RandomMobileBooksCollectionCards_CollectionId
    on RandomMobileBooksCollectionCards (CollectionId);

create table __EFMigrationsHistory
(
    MigrationId    TEXT not null
        constraint PK___EFMigrationsHistory
            primary key,
    ProductVersion TEXT not null
);

create table sqlite_master
(
    type     TEXT,
    name     TEXT,
    tbl_name TEXT,
    rootpage INT,
    sql      TEXT
);

create table sqlite_sequence
(
    name,
    seq
);


