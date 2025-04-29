create database CandidatesDB

go 
use CandidatesDB
create table Candidate
(
Id int identity(1,1),
[Name] nvarchar(100) not null,
NickName nvarchar(100) not null,
Email nvarchar(100) not null,
YearsOfExperience int not null ,
MaxNumSkills int not null ,

constraint Candidate_PK primary key (id)
)

create table Skill
(
Id int identity(1,1),
[Name] nvarchar(100) not null,

constraint Skill_PK primary key (id)
)

create table CandidateHasSkill
(
Candidate_Id int ,
Skill_Id int ,
GainedDate date not null,
constraint CandidateHasSkill_PK primary key (Candidate_Id,Skill_Id),
constraint CandidateHasSkill_Candidate_FK foreign key (Candidate_Id) references Candidate(Id) on delete cascade,
constraint CandidateHasSkill_Skill_FK foreign key (Skill_Id) references Skill(Id) on delete cascade
)