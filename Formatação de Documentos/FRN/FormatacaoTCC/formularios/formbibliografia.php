<div class="form">Insira a BIBLIOGRAFIA</div>
	
	<form method="POST" action= "visualizacao/bibliografia.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
		<div class="formulario">  
			<textarea name="bibliografia" class="ckeditor">
				<?php isset($bi) ? print $bi : false; ?>
			</textarea> 
			<br/><br/>
		</div>

		<input class="botao2" type="submit" value="Cadastrar">
</form>