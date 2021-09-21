create database indice;
use indice;

/*Tabela para armazenar as URLs*/
create table urls(
	idurl int not null auto_increment,
    url varchar (200) not null,
    constraint pk_urls_idurl primary key (idurl)
);

create index idx_urls_url on urls (url);

/*Armazena todas as palavras não repetidas no documento*/
create table palavras(
	idpalavra int not null auto_increment,
    palavra varchar (200) not null,
    constraint pk_palavras_palavra primary key (idpalavra)
);

create index idx_palavras_palavra on palavras(palavra);

create table palavra_localizacao(
	idpalavra_localizacao int not null auto_increment,
    idurl int not null,
    idpalavra int not null,
    localizacao int,
    constraint pk_idpalavra_localizacao primary key (idpalavra_localizacao),
    constraint fk_palavra_localizacao_idurl foreign key (idurl) references urls(idurl),
    constraint fk_palavra_localizacao_idpalavra foreign key (idpalavra) references palavras(idpalavra)
);

create index id_palavra_localizacao_idpalavra on palavra_localizacao(idpalavra);

alter database indice character set = utf8mb4 collate = utf8mb4_unicode_ci;
alter table palavras convert to character set utf8mb4 collate utf8mb4_unicode_ci;
alter table palavras modify column palavra varchar (200) character set utf8mb4 collate utf8mb4_unicode_ci;

create table url_ligacao(
	idurl_ligacao int not null auto_increment,
    idurl_origem int not null,
    idurl_destino int not null,
    constraint pk_idurl_ligacao primary key (idurl_ligacao),
    constraint fk_url_ligacao_idurl_origem foreign key (idurl_origem) references urls (idurl),
	constraint fk_url_ligacao_idurl_destino foreign key (idurl_destino) references urls (idurl)
);

create index idx_url_ligacao_idurlorigem on url_ligacao (idurl_origem);
create index idx_url_ligacao_idurldestino on url_ligacao (idurl_destino);

create table url_palavra (
	idurl_palavra int not null auto_increment,
    idpalavra int not null,
    idurl_ligacao int not null,
    constraint pk_url_palavra_idurl_palavra primary key (idurl_palavra),
    constraint fk_url_palavra_idpalavra foreign key (idpalavra) references palavras (idpalavra),
    constraint fk_url_palavra_url_ligacao foreign key (idurl_ligacao) references url_ligacao(idurl_ligacao)
);

create index idx_url_palavra_idpalavra on url_palavra(idpalavra);

create table page_rank(
	idurl int not null,
    nota float not null,
    constraint pk_page_rank_idurl primary key (idurl),
    constraint fk_page_rank_idurl foreign key (idurl) references urls(idurl)
);

insert into page_rank select idurl, 1.0 from urls;







