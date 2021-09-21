select * from urls;
select * from palavras;
select * from palavra_localizacao;
 
select count(*) from urls;
select count(*) from palavras;
select count(*) from palavra_localizacao;

select * from urls where url = 'teste';

insert into urls(url) values ('teste');
insert into palavras (palavra) values ('linguagem');
insert into palavra_localizacao (idurl, idpalavra, localizacao) values (1,1,5);

delete from palavra_localizacao;
delete from palavras;
delete from urls;

alter table urls auto_increment = 1;
alter table palavras auto_increment = 1;
alter table palavra_localizacao auto_increment = 1;

drop table palavra_localizacao;
drop table palavras;
drop table urls;


