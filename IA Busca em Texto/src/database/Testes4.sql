select * from palavras where palavra = 'python';
select * from palavras where palavra = 'program';

select 
	idurl,
    idpalavra,
    localizacao
from
	palavra_localizacao plc
where
	idpalavra = 244
and
	idpalavra = 2;

select p1.idurl, p1.localizacao, p2.localizacao
from palavra_localizacao p1, palavra_localizacao p2
where p1.idpalavra = 244
and p1.idurl = p2.idurl
and p2.idpalavra = 2;


select p1.idurl, p1.localizacao, p2.localizacao 
from  palavra_localizacao p1,  palavra_localizacao p2 
where p1.idpalavra = 244 
and p1.idurl = p2.idurl 
and p2.idpalavra = 2;


select* from urls;
select * from url_palavra;
select *  from url_ligacao;
select * from palavras where palavra = 'python';






