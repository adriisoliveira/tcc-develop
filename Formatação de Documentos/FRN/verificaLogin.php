<?php
session_start();

include_once("conexao.php");

if(isset($_SESSION['aluno']['login']) && isset($_SESSION['aluno']['senha'])){

	$usuario = $_SESSION['aluno']['login'];
	$senha = $_SESSION['aluno']['senha'];

	$sql = "SELECT * FROM aluno WHERE rm = '$usuario' AND senha = '$senha' LIMIT 1";

	$result = mysqli_query($conn, $sql);
	$resultado = mysqli_fetch_assoc($result);
	
	//Se resultado for igual a vazio
	if(empty($resultado)){
		header("Location: ../login.php?lg=erro");	
	}
	
}else{
	session_destroy();
	unset($_SESSION);
	header ("Location: ../login.php?lg=falha");
}