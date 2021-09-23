<div class="form">Insira os dados da FOLHA DE ROSTO!</div>
<form method="POST" action= "visualizacao/folhaderosto.php" >
	<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
	<div class="formulario">Nome da instituição: <input class="form3" name="instituicao" type="text" placeholder="Nome da sua instituição de ensino" value="<?=isset($inst) ? $inst : false?>"  required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Título do TCC: <input class="form2" name="titulo" type="text" placeholder="Título do seu TCC" value="<?=isset($ti) ? $ti : false?>" required="Obrigatório!" /> <br/><br/></div>
	<div class="formulario">Subtítulo do TCC: <input class="form4" name="subtitulo" type="text" placeholder="Subtítulo do seu TCC" value="<?=isset($subti) ? $subti : false?>" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Professor Orientador1: <input class="form33" name="orientador1" type="text" placeholder=" Nome do orientador EX: Profªxxx" value="<?=isset($or1) ? $or1 : false?>" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Professor Orientador2: <input class="form33" value="<?=isset($or2) ? $or2 : false?>" name="orientador2" type="text" placeholder=" Nome do orientador EX: Profªxxx" required="Obrigatório!" /> <br/><br/></div>
	<div class="formulario">Cidade, Estado: <input class="form6" name="cidade" value="<?=isset($ci) ? $ci : false?>" type="text" placeholder=" EX: São Paulo, SP " required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Ano: <input class="form7" name="ano" type="text" value="<?=isset($an) ? $an : false?>" placeholder=" EX: 2019 " required="Obrigatório!"/> <br/><br/></div>

	<input class="botao2" type="submit" value="Cadastrar">
</form>