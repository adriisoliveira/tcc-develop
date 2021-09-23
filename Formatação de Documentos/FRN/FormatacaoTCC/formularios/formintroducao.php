<div class="form">Insira os dados da INTRODUÇÃO!</div>
	
	<form method="POST" action= "visualizacao/introducao.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
		<div class="formulario">  
			<textarea name="intro" class="ckeditor">
				<?php isset($in) ? print $in : false; ?>
			</textarea> 
			<br/><br/>
		</div>

		<input class="botao2" type="submit" value="Cadastrar">
</form>