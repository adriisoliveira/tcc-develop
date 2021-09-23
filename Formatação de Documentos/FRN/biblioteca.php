<!DOCTYPE html>
<html lang="pt-br">
	<head>
		<meta charset="utf-8">
	</head>
	</body>
		<?php
			//REALIZA A CONEXAO COM O BANCO DE DADOS
			include_once("conexao.php");
			
			$arquivo = time().'.pdf';
			
			//cria variavel que vai receber os valores em um array
			$arq = isset($_FILES['arquivo']) ? $_FILES['arquivo'] : null;
			$nome = isset($_POST['nome_arquivo']) ? $_POST['nome_arquivo'] : 'sem nome';
					
			//Pasta onde o arquivo vai ser salvo
			//$_UP['pasta'] = 'pdf_user/';
			$destino = "pdf_user/".$arquivo;
			
			//Tamanho máximo do arquivo em Bytesq
			$_UP['tamanho'] = 1024*1024*100; //5mb
			
			//Array com a extensões permitidas
			$_UP['extensoes'] = ['pdf'];
			
			//Array com os tipos de erros de upload do PHP
			$_UP['erros'][0] = 'Não houve erro';
			$_UP['erros'][1] = 'O arquivo no upload é maior que o limite do PHP';
			$_UP['erros'][2] = 'O arquivo ultrapassa o limite de tamanho especificado no HTML';
			$_UP['erros'][3] = 'O upload do arquivo foi feito parcialmente';
			$_UP['erros'][4] = 'Não foi feito o upload do arquivo';
			
			//Verifica se houve algum erro com o upload. Sem sim, exibe a mensagem do erro
			if($arq['error'] != 0){
				die("Não foi possivel fazer o upload, erro: <br />". $_UP['erros'][$arq['error']]);
				exit; //Para a execução do script
			}
			
			//Faz a verificação da extensao do arquivo
			$extensao = pathinfo($arq['name'], PATHINFO_EXTENSION);
			//echo "<h1>".$extensao."</h1>";
			if(array_search($extensao, $_UP['extensoes']) === false){		

				echo "Por favor, envie arquivos com as seguintes extensões: PDF";

			}elseif($_UP['tamanho'] < $_FILES['arquivo']['size']){
				
				echo "<script type=\"text/javascript\">alert(\"Arquivo muito grande.\");</script>";
			
			//O arquivo passou em todas as verificações, hora de tentar move-lo para a pasta foto
			}else{

				if(move_uploaded_file($arq['tmp_name'], $destino)){
					//Upload efetuado com sucesso, exibe a mensagem
					$query = mysqli_query($conn, "INSERT INTO biblioteca SET bi_nome_arquivo = '$nome', bi_arquivo = '$destino'");
					
					echo "<script type=\"text/javascript\">alert(\"PDF cadastrado com Sucesso.\");</script>";	
					

				}else{
					//Upload não efetuado com sucesso, exibe a mensagem
					echo "<script type=\"text/javascript\">alert(\"PDF não foi cadastrado.\");</script>
					";
				}
			}
			
			
		?>
		
	</body>
</html>