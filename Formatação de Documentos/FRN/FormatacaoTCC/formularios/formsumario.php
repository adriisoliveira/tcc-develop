<div class="form">Insira o SUMÁRIO</div>
	
	<form method="POST" action= "visualizacao/sumario.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
		<div class="formulario">  
			<textarea name="sumario" class="ckeditor">
				<?php isset($su) ? print $su : false; ?>
			</textarea> 
			<br/><br/>
		</div>

		<input class="botao2" type="submit" value="Cadastrar">
</form>