/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2018-01-25 09:54:08                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GrupaNaprawcza') and o.name = 'FK_GRUPANAP_NALE¯Y DO_SERWISAN')
alter table GrupaNaprawcza
   drop constraint "FK_GRUPANAP_NALE¯Y DO_SERWISAN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GrupaNaprawcza') and o.name = 'FK_GRUPANAP_ZAJMUJE S_URZADZEN')
alter table GrupaNaprawcza
   drop constraint "FK_GRUPANAP_ZAJMUJE S_URZADZEN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Podatnik') and o.name = 'FK_PODATNIK_ROZLICZA _URZADSKA')
alter table Podatnik
   drop constraint "FK_PODATNIK_ROZLICZA _URZADSKA"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SerwisUrzadzenia') and o.name = 'FK_SERWISUR_JEST NAPR_URZADZEN')
alter table SerwisUrzadzenia
   drop constraint "FK_SERWISUR_JEST NAPR_URZADZEN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SerwisUrzadzenia') and o.name = 'FK_SERWISUR_WYKONYWAN_USLUGI')
alter table SerwisUrzadzenia
   drop constraint FK_SERWISUR_WYKONYWAN_USLUGI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Urzadzenie') and o.name = 'FK_URZADZEN_JEST ZAIN_MIEJSCE_')
alter table Urzadzenie
   drop constraint "FK_URZADZEN_JEST ZAIN_MIEJSCE_"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Urzadzenie') and o.name = 'FK_URZADZEN_MA_MODELURZ')
alter table Urzadzenie
   drop constraint FK_URZADZEN_MA_MODELURZ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Urzadzenie') and o.name = 'FK_URZADZEN_POSIADA_PODATNIK')
alter table Urzadzenie
   drop constraint FK_URZADZEN_POSIADA_PODATNIK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Administrator')
            and   type = 'U')
   drop table Administrator
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GrupaNaprawcza')
            and   name  = 'nale¿y do_FK'
            and   indid > 0
            and   indid < 255)
   drop index GrupaNaprawcza."nale¿y do_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GrupaNaprawcza')
            and   name  = 'zajmuje siê_FK'
            and   indid > 0
            and   indid < 255)
   drop index GrupaNaprawcza."zajmuje siê_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GrupaNaprawcza')
            and   type = 'U')
   drop table GrupaNaprawcza
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Handlowiec')
            and   type = 'U')
   drop table Handlowiec
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Miejsce_instalacji')
            and   type = 'U')
   drop table Miejsce_instalacji
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ModelUrzadzenia')
            and   type = 'U')
   drop table ModelUrzadzenia
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PamiecLogowania')
            and   type = 'U')
   drop table PamiecLogowania
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Podatnik')
            and   name  = 'rozlicza sie w_FK'
            and   indid > 0
            and   indid < 255)
   drop index Podatnik."rozlicza sie w_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Podatnik')
            and   type = 'U')
   drop table Podatnik
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SerwisUrzadzenia')
            and   name  = 'wykonywane s¹_FK'
            and   indid > 0
            and   indid < 255)
   drop index SerwisUrzadzenia."wykonywane s¹_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SerwisUrzadzenia')
            and   name  = 'jest naprawiane_FK'
            and   indid > 0
            and   indid < 255)
   drop index SerwisUrzadzenia."jest naprawiane_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SerwisUrzadzenia')
            and   type = 'U')
   drop table SerwisUrzadzenia
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Serwisant')
            and   type = 'U')
   drop table Serwisant
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UrzadSkarbowy')
            and   type = 'U')
   drop table UrzadSkarbowy
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Urzadzenie')
            and   name  = 'ma_FK'
            and   indid > 0
            and   indid < 255)
   drop index Urzadzenie.ma_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Urzadzenie')
            and   name  = 'posiada_FK'
            and   indid > 0
            and   indid < 255)
   drop index Urzadzenie.posiada_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Urzadzenie')
            and   name  = 'jest zainstalowane w_FK'
            and   indid > 0
            and   indid < 255)
   drop index Urzadzenie."jest zainstalowane w_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Urzadzenie')
            and   type = 'U')
   drop table Urzadzenie
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Uslugi')
            and   type = 'U')
   drop table Uslugi
go

/*==============================================================*/
/* Table: Administrator                                         */
/*==============================================================*/
create table Administrator (
   admin_id             int                  not null,
   nazwa                varchar(200)         not null,
   haslohash            varchar(64)          not null,
   salt                 varchar(64)          not null,
   constraint PK_ADMINISTRATOR primary key nonclustered (admin_id)
)
go

/*==============================================================*/
/* Table: GrupaNaprawcza                                        */
/*==============================================================*/
create table GrupaNaprawcza (
   grupa_id             int                  not null,
   serwisant_id         int                  not null,
   urzadzenie_id        int                  not null,
   ktory                int                  not null,
   constraint PK_GRUPANAPRAWCZA primary key nonclustered (grupa_id)
)
go

/*==============================================================*/
/* Index: "zajmuje siê_FK"                                      */
/*==============================================================*/
create index "zajmuje siê_FK" on GrupaNaprawcza (
urzadzenie_id ASC
)
go

/*==============================================================*/
/* Index: "nale¿y do_FK"                                        */
/*==============================================================*/
create index "nale¿y do_FK" on GrupaNaprawcza (
serwisant_id ASC
)
go

/*==============================================================*/
/* Table: Handlowiec                                            */
/*==============================================================*/
create table Handlowiec (
   handlowiec_id        int                  not null,
   imie                 varchar(50)          not null,
   nazwisko             varchar(50)          not null,
   telefon              varchar(200)         not null,
   haslohash            varchar(64)          not null,
   salt                 varchar(64)          not null,
   email                varchar(40)          null,
   constraint PK_HANDLOWIEC primary key nonclustered (handlowiec_id)
)
go

/*==============================================================*/
/* Table: Miejsce_instalacji                                    */
/*==============================================================*/
create table Miejsce_instalacji (
   miejsce_id           int                  not null,
   kraj                 varchar(30)          not null,
   wojewodztwo          varchar(25)          not null,
   miasto               varchar(25)          not null,
   ulica                varchar(50)          not null,
   constraint PK_MIEJSCE_INSTALACJI primary key nonclustered (miejsce_id)
)
go

/*==============================================================*/
/* Table: ModelUrzadzenia                                       */
/*==============================================================*/
create table ModelUrzadzenia (
   model_id             int                  not null,
   nazwa                varchar(200)         not null,
   constraint PK_MODELURZADZENIA primary key nonclustered (model_id)
)
go

/*==============================================================*/
/* Table: PamiecLogowania                                       */
/*==============================================================*/
create table PamiecLogowania (
   cred_id              int                  not null,
   zapamietany          varchar(100)         not null,
   constraint PK_PAMIECLOGOWANIA primary key nonclustered (cred_id)
)
go

/*==============================================================*/
/* Table: Podatnik                                              */
/*==============================================================*/
create table Podatnik (
   podatnik_id          int                  not null,
   urzad_id             int                  not null,
   nazwa                varchar(200)         not null,
   symbol               varchar(10)          not null,
   nip                  varchar(10)          not null,
   wojewodztwo          varchar(25)          not null,
   miasto               varchar(25)          not null,
   ulica                varchar(50)          not null,
   kod_pocztowy         varchar(6)           not null,
   telefon              varchar(200)         not null,
   email                varchar(40)          null,
   constraint PK_PODATNIK primary key nonclustered (podatnik_id)
)
go

/*==============================================================*/
/* Index: "rozlicza sie w_FK"                                   */
/*==============================================================*/
create index "rozlicza sie w_FK" on Podatnik (
urzad_id ASC
)
go

/*==============================================================*/
/* Table: SerwisUrzadzenia                                      */
/*==============================================================*/
create table SerwisUrzadzenia (
   serwis_id            int                  not null,
   usluga_id            int                  not null,
   urzadzenie_id        int                  not null,
   data_przyjecia       datetime             not null,
   data_oddania         datetime             null,
   cena                 decimal              not null,
   constraint PK_SERWISURZADZENIA primary key nonclustered (serwis_id)
)
go

/*==============================================================*/
/* Index: "jest naprawiane_FK"                                  */
/*==============================================================*/
create index "jest naprawiane_FK" on SerwisUrzadzenia (
urzadzenie_id ASC
)
go

/*==============================================================*/
/* Index: "wykonywane s¹_FK"                                    */
/*==============================================================*/
create index "wykonywane s¹_FK" on SerwisUrzadzenia (
usluga_id ASC
)
go

/*==============================================================*/
/* Table: Serwisant                                             */
/*==============================================================*/
create table Serwisant (
   serwisant_id         int                  not null,
   imie                 varchar(50)          not null,
   nazwisko             varchar(50)          not null,
   telefon              varchar(200)         not null,
   haslohash            varchar(64)          not null,
   salt                 varchar(64)          not null,
   email                varchar(40)          null,
   constraint PK_SERWISANT primary key nonclustered (serwisant_id)
)
go

/*==============================================================*/
/* Table: UrzadSkarbowy                                         */
/*==============================================================*/
create table UrzadSkarbowy (
   urzad_id             int                  not null,
   nazwa                varchar(200)         not null,
   miasto               varchar(25)          not null,
   ulica                varchar(50)          not null,
   constraint PK_URZADSKARBOWY primary key nonclustered (urzad_id)
)
go

/*==============================================================*/
/* Table: Urzadzenie                                            */
/*==============================================================*/
create table Urzadzenie (
   urzadzenie_id        int                  not null,
   podatnik_id          int                  not null,
   miejsce_id           int                  not null,
   model_id             int                  not null,
   nr_unikatowy         varchar(20)          not null,
   nr_ewidencyjny       varchar(20)          null,
   nr_fabryczny         varchar(20)          not null,
   data_uruchomienia    datetime             not null,
   ostatni_przeglad     datetime             not null,
   nastepny_przeglad    datetime             not null,
   data_likwidacji      datetime             null,
   co_ile_przeglad      int                  not null,
   constraint PK_URZADZENIE primary key nonclustered (urzadzenie_id)
)
go

/*==============================================================*/
/* Index: "jest zainstalowane w_FK"                             */
/*==============================================================*/
create index "jest zainstalowane w_FK" on Urzadzenie (
miejsce_id ASC
)
go

/*==============================================================*/
/* Index: posiada_FK                                            */
/*==============================================================*/
create index posiada_FK on Urzadzenie (
podatnik_id ASC
)
go

/*==============================================================*/
/* Index: ma_FK                                                 */
/*==============================================================*/
create index ma_FK on Urzadzenie (
model_id ASC
)
go

/*==============================================================*/
/* Table: Uslugi                                                */
/*==============================================================*/
create table Uslugi (
   usluga_id            int                  not null,
   nazwa                varchar(200)         not null,
   koszt_brutto         decimal              null,
   constraint PK_USLUGI primary key nonclustered (usluga_id)
)
go

alter table GrupaNaprawcza
   add constraint "FK_GRUPANAP_NALE¯Y DO_SERWISAN" foreign key (serwisant_id)
      references Serwisant (serwisant_id)
go

alter table GrupaNaprawcza
   add constraint "FK_GRUPANAP_ZAJMUJE S_URZADZEN" foreign key (urzadzenie_id)
      references Urzadzenie (urzadzenie_id)
go

alter table Podatnik
   add constraint "FK_PODATNIK_ROZLICZA _URZADSKA" foreign key (urzad_id)
      references UrzadSkarbowy (urzad_id)
go

alter table SerwisUrzadzenia
   add constraint "FK_SERWISUR_JEST NAPR_URZADZEN" foreign key (urzadzenie_id)
      references Urzadzenie (urzadzenie_id)
go

alter table SerwisUrzadzenia
   add constraint FK_SERWISUR_WYKONYWAN_USLUGI foreign key (usluga_id)
      references Uslugi (usluga_id)
go

alter table Urzadzenie
   add constraint "FK_URZADZEN_JEST ZAIN_MIEJSCE_" foreign key (miejsce_id)
      references Miejsce_instalacji (miejsce_id)
go

alter table Urzadzenie
   add constraint FK_URZADZEN_MA_MODELURZ foreign key (model_id)
      references ModelUrzadzenia (model_id)
go

alter table Urzadzenie
   add constraint FK_URZADZEN_POSIADA_PODATNIK foreign key (podatnik_id)
      references Podatnik (podatnik_id)
go

