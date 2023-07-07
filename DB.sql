use master
go

if exists(select * from sys.databases where name = 'LinkWave')
    drop database LinkWave

create database LinkWave
go

use LinkWave
go

create table Users(
    User_id int identity primary key not null,
    Username varchar(30) not null,
    Email varchar(100) not null,
    PasswordHash char(64) not null,
    Salt char(16) not null,
    Picture varchar(200) not null,
    BirthDate date not null
);
go

create table Forums(
    Forum_id int identity primary key not null,
    Name varchar(40) not null,
    Description varchar(150) not null,
    Created_at date not null
);
go

create table Positions(
    Position_id int identity primary key,
    Name varchar(30),
    Forum_id int,
    foreign key (Forum_id) references Forums(Forum_id),
);
go

create table ForumUser(
    Association_id int identity primary key,
    User_id int,
    Forum_id int,
	Position_id int,
    foreign key (User_id) references Users(User_id),
    foreign key (Forum_id) references Forums(Forum_id),
	foreign key (Position_id) references Positions(Position_id)
);
go

create table Posts(
    Post_id int identity primary key,
    Title varchar(50),
    Content varchar(500),
    Picture varchar(200),
    User_id int,
    Forum_id int,
    foreign key (User_id) references Users(User_id),
    foreign key (Forum_id) references Forums(Forum_id),
);
go

create table Permissions(
    Permission_id int identity primary key,
    Name varchar(50)
);
go

insert into Permissions VALUES
	('See posts'),
	('Make post (title, content, image)'),
	('Like (+1).'),
	('Dislike (-1).'),
	('Remove posts.'),
	('Remove members.'),
	('Edit posts.'),
	('Promote members (change their position)'),
	('Create/Edit positions.'),
	('Delete forum.');
go

create table PosPerm(
    PosPerm_id int identity primary key,
    Permission_id int,
    Position_id int,
    foreign key (Permission_id) references Permissions(Permission_id),
    foreign key (Position_id) references Positions(Position_id)
);

create table Ratings(
    Rating_id int identity primary key,
    Rating bit,
    User_id int,
    Post_id int,
    foreign key (User_id) references Users(User_id),
    foreign key (Post_id) references Posts(Post_id)
);