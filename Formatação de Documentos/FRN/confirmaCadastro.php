<?php
include_once("conexao.php");

if(isset($_GET['token']) && !empty($_GET['token'])){

	$senha = $_GET['token'];

	$sql = "SELECT * FROM aluno WHERE senha = '$senha' LIMIT 1";

	$result = mysqli_query($conn, $sql);
	$resultado = mysqli_fetch_assoc($result);
	
	//Se resultado for igual a vazio
	if(empty($resultado)){
		echo 'Houve uma falha ao confirmar seu cadastro.';
	}else{
		$sql = "UPDATE aluno SET confirmado=1 WHERE senha='$senha'";
		mysqli_query($conn, $sql);
		echo 'Cadastro confirmado com sucesso!<br><a href="login.php">Fazer Login</a>';
	}
	
}else{
	echo 'Houve uma falha ao confirmar seu cadastro.';
}