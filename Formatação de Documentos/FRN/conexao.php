<?php
	$servidor = "localhost";
	$usuario = "root";
	$senha = "";
	$dbname = "athenas";
	$URL_BASE = 'https://localhost/tabata/projeto';
	
	//Criar a conexão
	$conn = mysqli_connect($servidor, $usuario, $senha, $dbname);
	
	//
	if(!$conn){
		die("Falha na conexao " . mysqli_connect_error());
	}else{
		
	}
?>