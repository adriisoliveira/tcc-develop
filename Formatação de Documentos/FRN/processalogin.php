<?php
session_start();

include_once("conexao.php");

	if(isset($_POST['nomeuser']) && isset($_POST['senha'])){
		//evita o mysqli injection
		$usuario = filter_input(INPUT_POST, 'nomeuser', FILTER_SANITIZE_FULL_SPECIAL_CHARS);
		//evita o uso de mysql injection
		$senha = $_POST['senha'];
		//criptografa a senha
		$senha = md5($senha);
		//Coloca uma uma string com uma query que tem os valores das variaveis usuario e senha dentro da variavel sql
		$sql = "SELECT * FROM aluno WHERE rm = '$usuario' AND senha = '$senha' AND confirmado=1 LIMIT 1";
		//Coloca a string que está na variavel sql e a variavel $conn como parametros da função mysqli_query para serem executados e o valor de reposta ser armazenado na variavel $result
		$result = mysqli_query($conn, $sql);
		$resultado = mysqli_fetch_assoc($result);
		
		//Se resultado for igual a vazio
		if(empty($resultado)){
			//O VALOR DA SESSAO SERA IGUAL A LOGINERRO
			$_SESSION['loginErro'] = "Usuario ou senha inválidos";
			header("Location: login.php");	
		}elseif (!empty($resultado)){
			//Preechendo as sessões com os dados do aluno logado
			$_SESSION['logado'] = true;
			$_SESSION['aluno']['id'] = $resultado['id_aluno'];
			$_SESSION['aluno']['login'] = $resultado['rm'];
			$_SESSION['aluno']['senha'] = $resultado['senha'];
			$_SESSION['aluno']['nome'] = $resultado['nm_aluno'];
			$_SESSION['nome'] = $resultado['nm_aluno'];

			header("Location: FormatacaoTCC/tcc.php");
		}else{
			$_SESSION['loginErro'] = "Usuario ou senha estão incorretos";
			header("Location: login.php");
		}
		
	}else{
		$_SESSION['loginErro'] = "Usuario ou senha estão incorretos";
		header ("Location: login.php");
	}