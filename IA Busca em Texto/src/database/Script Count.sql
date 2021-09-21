select count(*) from urls where idurl in (select idurl from palavra_localizacao);
select count(*) from palavra_localizacao;
select count(*) from url_ligacao;
select count(*) from url_palavra;

select * from url_ligacao;
select * from urls order by idurl;
select count(*) from url_ligacao where idurl_destino = 2826;