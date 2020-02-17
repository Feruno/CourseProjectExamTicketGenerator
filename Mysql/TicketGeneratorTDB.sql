drop database if exists Ticket_generator9;

CREATE DATABASE if not exists Ticket_generator9;

use ticket_generator9;
    
CREATE TABLE discipline (
  id_discipline integer (10) not null auto_increment,
  Name_discipline varchar(20)not null,
  primary key (id_discipline));
  
CREATE TABLE teacher(
  id_Teacher integer(10) not null auto_increment,
  first_name varchar(50),
  last_name varchar(50),  
  midl_name varchar(50),
  primary key (id_Teacher));

CREATE TABLE specialties(
  id_Specialty integer(10) not null auto_increment,
  num_Specialty integer (10) not null,
  Name_specialty varchar(50),
  primary key (id_Specialty));
  
CREATE TABLE Groups(
  id_Group integer(10) not null auto_increment,
  code_group integer (10),
  Specialty_code integer(10),
  primary key (id_Group),
  foreign key (id_Group) references specialties (id_Specialty )
  on delete no action
  on update cascade  );
  
  
CREATE TABLE Question (
  id_Question integer (10) not null auto_increment,
  Question_type varchar(20),
  Question varchar(200),
  Code_discipline integer(10),
  que_selected int ,
  primary key (id_Question, Code_discipline),
  foreign key (Code_discipline) references discipline (id_discipline)
  on update cascade
  on delete no action);

CREATE TABLE Cyclic_commission(
  Code_Cyclic_commission integer(10) not null auto_increment,
  Name_commission varchar(20),
  Chairmans_Name varchar(20),
  primary key (Code_Cyclic_commission));
  
create table exam (
  id_exam integer (10)not null auto_increment,
  date_ date,
  course varchar(10),
  code_cpec integer(10),
  code_disc integer(10),
  code_teacher integer(10),
  semestr integer(10),
  ID_Cyclic_commission integer(10),
  primary key (id_exam),
  foreign key (code_teacher) references teacher (id_Teacher)
  on update cascade
  on delete no action,
  foreign key (code_disc) references discipline (id_discipline)
  on update cascade
  on delete no action,
  foreign key (code_cpec) references specialties (id_Specialty)
  on update cascade
  on delete no action,
  foreign key (ID_Cyclic_commission) references Cyclic_commission (Code_Cyclic_commission)
  on update cascade
  on delete no action);

create table Ticket (
  id_T integer(10) not null auto_increment,
  id_Ticket integer(10),
  id_Question_selected integer ,
  id_Question integer (10),
  id_discipline integer (10),
  id_exam integer(10),
  primary key (id_T),
  foreign key (id_discipline, id_Question_selected) references Question (Code_discipline, id_Question)
  on update cascade
  on delete no action,  
  foreign key (id_exam) references exam (id_exam)
  on update cascade
  on delete no action);