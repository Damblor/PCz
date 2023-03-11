-- tabele
if exists(
  select name
  from sysobjects
  where sysobjects.name='FK_Samochody_Wlasciciele'
)
alter table Samochody
drop constraint FK_Samochody_Wlasciciele
go

if exists(
  select name
  from sysobjects
  where sysobjects.name='Wlasciciele'and sysobjects.type='U'
)
drop table Wlasciciele
go

create table Wlasciciele(
  IdWlasciciela int not null identity(1,1),
  Nazwisko nvarchar(20) not null,
  Imie nvarchar(20) not null
)

if exists(
  select name
  from sysobjects
  where sysobjects.name='Samochody'and sysobjects.type='U'
)
drop table Samochody
go

create table Samochody(
  IdSamochodu int not null identity(1,1),
  Marka nvarchar(20) not null,
  Model nvarchar(20) not null,
  NumerRejestracyjny nvarchar(20) not null,
  IdWlasciciela int not null
)
go

if exists(
  select name
  from sysobjects
  where sysobjects.name='PK_Wlasciciele'
)
alter table Wlasciciele
drop constraint PK_Wlasciciele
go

alter table Wlasciciele
add constraint PK_Wlasciciele primary key(
  IdWlasciciela
)
go

if exists(
  select name
  from sysobjects
  where sysobjects.name='PK_Samochody'
)
alter table Samochody
drop constraint PK_Samochody
go

alter table Samochody
add constraint PK_Samochody primary key(
  IdSamochodu
)
go

alter table Samochody
add constraint FK_Samochody_Wlasciciele foreign key(
  IdWlasciciela
)
references Wlasciciele(
  IdWlasciciela
)
on update cascade
go

-- przykładowe dane
insert into Wlasciciele(Nazwisko,Imie)
values('Kowal','Jan')
insert into Wlasciciele(Nazwisko,Imie)
values('Walas','Andrzej')
go

insert into Samochody(Marka,Model,NumerRejestracyjny,IdWlasciciela)
values('Toyota','Yaris','SC12345',1)
insert into Samochody(Marka,Model,NumerRejestracyjny,IdWlasciciela)
values('Honda','Jazz','SC12321',1)
insert into Samochody(Marka,Model,NumerRejestracyjny,IdWlasciciela)
values('Honda','Accord','SC54321',2)
go

-- procedury składowane do wstawiania

if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Wlasciciele_insert'and sysobjects.type='P'
)
drop procedure SP_Wlasciciele_insert
go

create procedure SP_Wlasciciele_insert
  @Nazwisko nvarchar(20),
  @Imie nvarchar(20)
as
  insert into Wlasciciele(Nazwisko,Imie)
  values(@Nazwisko,@Imie)
return 
go

exec SP_Wlasciciele_insert @Nazwisko='Kowalska',@Imie='Anna'
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_insert'and sysobjects.type='P'
)
drop procedure SP_Samochody_insert
go

create procedure SP_Samochody_insert
  @Marka nvarchar(20),
  @Model nvarchar(20),
  @NumerRejestracyjny nvarchar(20),
  @IdWlasciciela int
as
  -- PROSZĘ SAMEMU WPISAĆ KOD
return
go

exec SP_Samochody_insert @Marka='Audi',@Model='A8',@NumerRejestracyjny='SC87654',@IdWlasciciela=2
go

-- procedury składowane do usuwania

if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Wlasciciele_delete'and sysobjects.type='P'
)
drop procedure SP_Wlasciciele_delete
go

create procedure SP_Wlasciciele_delete
  @Nazwisko nvarchar(20),
  @Imie nvarchar(20)
as
  delete from Wlasciciele
  where
    (Nazwisko like @Nazwisko)and
    (Imie like @Imie)
return 
go

exec SP_Wlasciciele_delete @Nazwisko='Kowalska',@Imie='Anna'
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_delete'and sysobjects.type='P'
)
drop procedure SP_Samochody_delete
go

create procedure SP_Samochody_delete
  @Marka nvarchar(20)='%',
  @Model nvarchar(20)='%',
  @NumerRejestracyjny nvarchar(20)
as
  -- PROSZĘ SAMEMU WPISAĆ KOD
return
go

exec SP_Samochody_delete @Marka='Audi',@Model='A8',@NumerRejestracyjny='SC87654'
go

-- procedury składowane do aktualizacji

if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Wlasciciele_update'and sysobjects.type='P'
)
drop procedure SP_Wlasciciele_update
go

create procedure SP_Wlasciciele_update
  @Nazwisko nvarchar(20),
  @Imie nvarchar(20),
  @NazwiskoNowe nvarchar(20),
  @ImieNowe nvarchar(20)
as
  update Wlasciciele
  set 
    Nazwisko=@NazwiskoNowe,
    Imie=@ImieNowe
  where
    (Nazwisko like @Nazwisko)and
    (Imie like @Imie)
return 
go

exec SP_Wlasciciele_insert @Nazwisko='Kowalska',@Imie='Anna'
go

exec SP_Wlasciciele_update 
  @Nazwisko='Kowalska',@Imie='Anna',
  @NazwiskoNowe='Kowalska-Satyna',@ImieNowe='Anna'
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_update'and sysobjects.type='P'
)
drop procedure SP_Samochody_update
go

create procedure SP_Samochody_update
  @Marka nvarchar(20)='%',
  @Model nvarchar(20)='%',
  @NumerRejestracyjny nvarchar(20),
  @IdWlasciciela int,
  @MarkaNowa nvarchar(20),
  @ModelNowy nvarchar(20),
  @NumerRejestracyjnyNowy nvarchar(20),
  @IdWlascicielaNowy int
as
  -- PROSZĘ SAMEMU WPISAĆ KOD
return
go

exec SP_Samochody_insert @Marka='Audi',@Model='A8',@NumerRejestracyjny='SC87654',@IdWlasciciela=2
go
exec SP_Samochody_update 
  @Marka='Audi',@Model='A8',@NumerRejestracyjny='SC87654',@IdWlasciciela=2,
  @MarkaNowa='Audi',@ModelNowy='A8',@NumerRejestracyjnyNowy='SK87654',@IdWlascicielaNowy=1
go

-- procedury składowane do selekcji

if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Wlasciciele_select'and sysobjects.type='P'
)
drop procedure SP_Wlasciciele_select
go

create procedure SP_Wlasciciele_select
  @Nazwisko nvarchar(20)='%',
  @Imie nvarchar(20)='%'
  -- ,@ParametrWyjściowy int output
as
  select
    Wlasciciele.IdWlasciciela as 'Identyfikator właściciela',
    Wlasciciele.Nazwisko as 'Nazwisko',
    Wlasciciele.Imie as 'Imię'
  from 
    Wlasciciele
  where 
    (Wlasciciele.Nazwisko like @Nazwisko) and
    (Wlasciciele.Imie like @Imie)
  order by
    Wlasciciele.Nazwisko
return 
go

exec SP_Wlasciciele_select @Nazwisko='%',@Imie='%'
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_select'and sysobjects.type='P'
)
drop procedure SP_Samochody_select
go

create procedure SP_Samochody_select
  @Marka nvarchar(20)='%',
  @Model nvarchar(20)='%',
  @NumerRejestracyjny nvarchar(20)='%',
  @Nazwisko nvarchar(20)='%',
  @Imie nvarchar(20)='%'
as
  -- PROSZĘ SAMEMU WPISAĆ KOD
return 
go

exec SP_Samochody_select
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Wlasciciele_select_liczba'and sysobjects.type='P'
)
drop procedure SP_Wlasciciele_select_liczba
go

create procedure SP_Wlasciciele_select_liczba
as
  select
    Count(Wlasciciele.IdWlasciciela) as 'Liczba właścicieli'
  from 
    Wlasciciele
return 
go

exec SP_Wlasciciele_select_liczba
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_select_liczba'and sysobjects.type='P'
)
drop procedure SP_Samochody_select_liczba
go

create procedure SP_Samochody_select_liczba
as
  -- PROSZĘ SAMEMU WPISAĆ KOD
return 
go

exec SP_Samochody_select_liczba
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_select_liczba_samochodow'and sysobjects.type='P'
)
drop procedure SP_Samochody_select_liczba_samochodow
go

create procedure SP_Samochody_select_liczba_samochodow
as
  select
    Wlasciciele.Nazwisko as 'Nazwisko właściciela',
    Wlasciciele.Imie as 'Imię właściciela',
    count(Samochody.IdWlasciciela) as 'Liczba posiadanych samochodów'
  from 
    Wlasciciele left join Samochody -- także ci posiadający 0 aut
    on Wlasciciele.IdWlasciciela=Samochody.IdWlasciciela
  group by 
    Wlasciciele.IdWlasciciela,Wlasciciele.Nazwisko,Wlasciciele.Imie
return 
go

exec SP_Samochody_select_liczba_samochodow
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_select_liczba_samochodow_wieksza_niz_0'and sysobjects.type='P'
)
drop procedure SP_Samochody_select_liczba_samochodow_wieksza_niz_0
go

create procedure SP_Samochody_select_liczba_samochodow_wieksza_niz_0
as
  select
    Wlasciciele.Nazwisko as 'Nazwisko właściciela',
    Wlasciciele.Imie as 'Imię właściciela',
    count(Samochody.IdWlasciciela) as 'Liczba posiadanych samochodów'
  from 
    Wlasciciele left join Samochody -- także ci posiadający 0 aut
    on Wlasciciele.IdWlasciciela=Samochody.IdWlasciciela
  group by 
    Wlasciciele.IdWlasciciela,Wlasciciele.Nazwisko,Wlasciciele.Imie
  having 
    count(Samochody.IdWlasciciela)>0;
return 
go

exec SP_Samochody_select_liczba_samochodow_wieksza_niz_0
go


if exists(
  select name
  from sysobjects
  where sysobjects.name='SP_Samochody_select_wlasciciele_o_max_i_min'and sysobjects.type='P'
)
drop procedure SP_Samochody_select_wlasciciele_o_max_i_min
go

-- 
create procedure SP_Samochody_select_wlasciciele_o_max_i_min
as
  select
    Wlasciciele.Nazwisko as 'Nazwisko właściciela',
    Wlasciciele.Imie as 'Imię właściciela',
    count(Samochody.IdWlasciciela) as 'Liczba posiadanych samochodów'
  from 
    Wlasciciele left join Samochody -- także ci posiadający 0 aut
    on Wlasciciele.IdWlasciciela=Samochody.IdWlasciciela
  group by 
    Wlasciciele.IdWlasciciela,Wlasciciele.Nazwisko,Wlasciciele.Imie
  having (
    count(Samochody.IdWlasciciela)>=max(Samochody.IdWlasciciela)or
    count(Samochody.IdWlasciciela)<=min(Samochody.IdWlasciciela)
  );
return 
go

exec SP_Samochody_select_wlasciciele_o_max_i_min
go
