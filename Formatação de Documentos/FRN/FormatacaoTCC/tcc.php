<?php
	SESSION_START();
	
	require_once "../conexao.php";
?>
<!DOCType html>
<html>
<head>
<title>Divs</title>
<link rel="stylesheet" type="text/css" href="css/style12.css" media="screen" />
<script type="text/javascript" src="ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="script.js"></script>
<meta charset="utf-8"/>
</head>
	<body>
		<!--Primeira DIV do lado Esquerdo da tela-->
		<div class="div1">
			<div class="seila"><img src="fotos/logonova.jpg"><br></div>
			 <br><a href="./tcc.php?p=capa">Capa</a></br></br>
			 <a href="./tcc.php?p=folhaderosto">Folha de Rosto</a></br> </br>
			 <a href="./tcc.php?p=sumario">Sumário</a></br> </br>
			 <a href="./tcc.php?p=introducao">Introdução</a></br> </br>
			 <a href="./tcc.php?p=justificativa">Justificativa</a></br> </br>
			 <a href="./tcc.php?p=dev">Desenvolvimento</a></br> </br>
			 <a href="./tcc.php?p=bibliografia">Bibliografia</a></br> </br>
			 <a href="gera-pdf.php">Gerar PDF dos Dados</a></br> </br>
			 <a href="../index.php">Sair</a></br> </br>
			</div>
		</div>
		<div class="div1">
			<?php
				$sql = "SELECT * FROM trabalhos WHERE tr_aluno='{$_SESSION['id']}'";
				$trab = mysqli_query($conn, $sql);
				if(mysqli_num_rows($trab) > 0) {

					$TR = mysqli_fetch_array($trab);
					$id = $TR['tr_id'];
					$in = $TR['tr_introducao'];
					$cp = $TR['tr_capa'];
					$fr = $TR['tr_folha_rosto'];
					$de = $TR['tr_dev'];
					$su = $TR['tr_sumario'];
					$dt = $TR['tr_data'];
					$ju = $TR['tr_justificativa'];
					$bi = $TR['tr_bibliografia'];
					$ti = $TR['tr_titulo'];
					$subti = $TR['tr_subtitulo'];
					$inst = $TR['tr_instituicao'];
					$inte1 = $TR['tr_integrante1'];
					$inte2 = $TR['tr_integrante2'];
					$inte3 = $TR['tr_integrante3'];
					$inte4 = $TR['tr_integrante4'];
					$inte5 = $TR['tr_integrante5'];
					$an = $TR['tr_ano'];
					$or1 = $TR['tr_orientador1'];
					$or2 = $TR['tr_orientador2'];
					$ci = $TR['tr_cidade'];

				}
				//QUANDO QUISER IGNORAR O ERRO COLOQUE O @
				$valor = isset($_GET['p']) ? $_GET['p'] : false;

				switch($valor) {
					case 'capa':
						require_once 'formularios/formcapa.php';
						break;
					case 'folhaderosto':
						require_once 'formularios/formfolhaderosto.php';
						break;
					case 'introducao':
						require_once 'formularios/formintroducao.php';
						break;
					case 'sumario':
						require_once 'formularios/formsumario.php';
						break;
					case 'dev':
						require_once 'formularios/formdev.php';
						break;
					case 'justificativa':
						require_once 'formularios/formjustificativa.php';
						break;
					case 'bibliografia':
						require_once 'formularios/formbibliografia.php';
						break;
					default:
						print '<h3 style="margin-top:50%">Escolha uma das opções ao lado</h3>';
				}
			?>
		</div>
	</body>
</html>