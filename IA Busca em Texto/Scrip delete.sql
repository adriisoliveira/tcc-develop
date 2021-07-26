delete from url_palavra;
delete from url_ligacao;
delete from palavra_localizacao;
delete from palavras;
delete from urls;

alter table urls auto_increment = 1;
alter table palavras auto_increment = 1;
alter table palavra_localizacao auto_increment = 1;
alter table url_ligacao auto_increment = 1;
alter table url_palavra auto_increment = 1;