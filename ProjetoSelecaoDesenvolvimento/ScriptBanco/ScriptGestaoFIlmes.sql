create table Filmes (
	id serial primary key,
	titulo varchar(255) not null,
	mes_lancamento int not null,
	ano_lancamento int not null,
	genero_id int not null,
	foreign key (genero_id) references Generos(id)
);

create table Generos (
	id serial primary key,
	nome varchar(255) not null
);

create table Streamings (
	id serial primary key,
	nome varchar(100) not null
);

create table Filmes_Streamings (
	id serial,
	filme_id int not null,
	streaming_id int not null,
	primary key (filme_id, streaming_id, id),
	foreign key (filme_id) references Filmes(id),
	foreign key (streaming_id) references Streamings(id)
);

create table Avaliacoes (
	id serial primary key,
	filme_id int not null,
	usuario_id int not null,
	avaliacao int not null check (avaliacao >= 1 and avaliacao <=5),
	comentario text,
	foreign key (filme_id) references Filmes(id),
	foreign key (usuario_id) references Usuarios (id)
);

create table Usuarios (
	id serial primary key,
	nome varchar(100) not null
);

select * from generos;
select * from filmes;
select * from usuarios;
select * from streamings;
select * from avaliacoes;
select * from filmes_streamings;