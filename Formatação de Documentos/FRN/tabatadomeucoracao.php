<!DOCType html>
<html>
<head>
<title>Divs</title>
<link rel="stylesheet" type="text/css" href="css/style12.css" media="screen" />

<script type="text/javascript" src="script.js"></script>
<meta charset="utf-8"/>
</head>
 
<body>

<!--Primeira DIV do lado Esquerdo da tela-->
<div class="div1">
<div class="seila"><img src="fotos/logonova.jpg"><br></div>
 <br><button class="botao" type="button" onclick="Mudarestado('divCapa')">CAPA</button></br></br>
 <button class="botao" type="button" onclick="Mudarestado('divFolhaDeRosto')">FOLHA DE ROSTO</button></br> </br>
 <button class="botao" type="button" onclick="Mudarestado('divintroducao')">INTRODUÇÃO</button></br></br> 
 <button class="botao" href="sair.php">Sair</button>
</div>

<!--Segunda DIV do lado direito da tela-->
<div id="divCapa" style="display:none" class="div2" />
<div class="form">Insira os dados da CAPA!</div>
	<form method="POST" action= "tabata.php" >
	<div class="formulario">Nome da instituição: <input class="form3" name="nomedainstituicao" type="text" placeholder="Nome da sua instituição de ensino " required="Obrigatório!" /> <br/><br/></div>
	<div class="formulario">Titulo do TCC: <input class="form2" name="titulodotcc" type="text" placeholder="Título do seu TCC" required="Obrigatório!" />  <br/><br/></div>
	<div class="formulario"> Subtítulo do TCC: <input class="form4" name="subtitulodotcc" type="text" placeholder="Subtítulo do seu TCC" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Nome do integrante1: <input class="form5" name="nomedointegrante1" type="text" placeholder=" Nome do integrante 1" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Nome do integrante2: <input class="form5" name="nomedointegrante2" type="text" placeholder=" Nome do integrante 2" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Nome do integrante3: <input class="form5" name="nomedointegrante3" type="text" placeholder=" Nome do integrante 3" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Nome do integrante4: <input class="form5" name="nomedointegrante4" type="text" placeholder=" Nome do integrante 4" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Nome do integrante5: <input class="form5" name="nomedointegrante5" type="text" placeholder=" Nome do integrante 5" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Cidade, Estado: <input class="form6" name="cidadeestado" type="text" placeholder=" EX: São Paulo, SP " required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Ano: <input class="form7" name="ano" type="text" placeholder=" EX: 2019 " required="Obrigatório!"/> <br/><br/></div>
		
	<input class="botao2" type="submit" value="Cadastrar">
</form>
</div>

<div id="divFolhaDeRosto" style="display:none" class="div2">
	<div class="form">Insira os dados da FOLHA DE ROSTO!</div>
	<form method="POST" action= "tabata2.php" >
	<div class="formulario">Nome da instituição: <input class="form3" name="nomedainstituicao" type="text" placeholder="Nome da sua instituição de ensino" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Título do TCC: <input class="form2" name="titulodotcc" type="text" placeholder="Título do seu TCC" required="Obrigatório!" /> <br/><br/></div>
	<div class="formulario">Subtítulo do TCC: <input class="form4" name="subtitulodotcc" type="text" placeholder="Subtítulo do seu TCC" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Professor Orientador1: <input class="form33" name="nomedoorientador1" type="text" placeholder=" Nome do orientador EX: Profªxxx" required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Professor Orientador2: <input class="form33" name="nomedoorientador2" type="text" placeholder=" Nome do orientador EX: Profªxxx" required="Obrigatório!" /> <br/><br/></div>
	<div class="formulario">Cidade, Estado: <input class="form6" name="cidadeestado" type="text" placeholder=" EX: São Paulo, SP " required="Obrigatório!"/> <br/><br/></div>
	<div class="formulario">Ano: <input class="form7" name="ano" type="text" placeholder=" EX: 2019 " required="Obrigatório!"/> <br/><br/></div>
		
	<input class="botao2" type="submit" value="Cadastrar">
</form>
</div>

 <div id="divintroducao" style="display:none" class="div2">
<div class="form">Insira os dados da INTRODUÇÃO!</div>
	<form method="POST" action= "tabata3.php" >
	<div class="formulario"> <div class="formulario2">Primeiro parágrafo:</div><br> <input class="form18" name="primeiroparagrafo" type="text" placeholder=" Primeiro Parágrafo da sua introdução (6 à 7 linhas) "/> <br/><br/></div>
	<div class="formulario"> <div class="formulario2">Segundo parágrafo:</div><br> <input class="form18" name="segundoparagrafo" type="text" placeholder="Segundo Parágrafo da sua introdução (6 à 7 linhas) "/> <br/><br/></div>
		
	<input class="botao2" type="submit" value="Cadastrar">
</form>
</div>


</body>
</html>