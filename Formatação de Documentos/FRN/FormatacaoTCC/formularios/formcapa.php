<div class="form">Insira os dados da CAPA!</div>
	<form method="POST" action= "visualizacao/capa.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
 
			<div class="formulario">Nome da instituição: <input class="form3" name="instituicao" type="text" value="<?=isset($inst) ? $inst : false?>" placeholder="Nome da sua instituição de ensino " required="Obrigatório!" /> <br/><br/></div>
			<div class="formulario">Titulo do TCC: <input class="form2" name="titulo" type="text" placeholder="Título do seu TCC" value="<?=isset($ti) ? $ti : false?>" required="Obrigatório!" />  <br/><br/></div>
			<div class="formulario"> Subtítulo do TCC: <input class="form4" name="subtitulo" type="text" placeholder="Subtítulo do seu TCC" required="Obrigatório!" value="<?=isset($subti) ? $subti : false?>"/> <br/><br/></div>
			<div class="formulario">Nome do integrante1: <input class="form5" name="integrante1" type="text" placeholder=" Nome do integrante 1" value="<?=isset($inte1) ? $inte1 : false?>" required="Obrigatório!"/> <br/><br/></div>
			<div class="formulario">Nome do integrante2: <input class="form5" name="integrante2" type="text" placeholder=" Nome do integrante 2" required="Obrigatório!" value="<?=isset($inte2) ? $inte2 : false?>" /> <br/><br/></div>
			<div class="formulario">Nome do integrante3: <input class="form5" name="integrante3" type="text" placeholder=" Nome do integrante 3" required="Obrigatório!" value="<?=isset($inte3) ? $inte3 : false?>" /> <br/><br/></div>
			<div class="formulario">Nome do integrante4: <input class="form5" name="integrante4" type="text" placeholder=" Nome do integrante 4" required="Obrigatório!" value="<?=isset($inte4) ? $inte4 : false?>" /> <br/><br/></div>
			<div class="formulario">Nome do integrante5: <input class="form5" name="integrante5" type="text" placeholder=" Nome do integrante 5" required="Obrigatório!" value="<?=isset($inte5) ? $inte5 : false?>" /> <br/><br/></div>
			<div class="formulario">Cidade, Estado: <input class="form6" name="cidade" type="text" placeholder=" EX: São Paulo, SP " required="Obrigatório!" value="<?=isset($ci) ? $ci : false?>" /> <br/><br/></div>
			<div class="formulario">Ano: <input class="form7" name="ano" type="text" value="<?=isset($an) ? $an : false?>" placeholder=" EX: 2019 " required="Obrigatório!"/> <br/></div>

	<input class="botao2" type="submit" value="Cadastrar">
</form>