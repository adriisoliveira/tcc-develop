<?php
SESSION_START();
require_once('../../conexao.php');

$intro = isset($_POST['intro']) ? $_POST['intro'] : 'não informado';
$id = (isset($_POST['id']) && !empty($_POST['id'])) ? (int)$_POST['id'] : null;

if(!empty($id)) {
    $sql = "UPDATE trabalhos SET tr_introducao='$intro' WHERE tr_id='$id'";
    mysqli_query($conn, $sql);
}else{
    $sql = "INSERT INTO trabalhos SET tr_aluno='{$_SESSION['aluno']['id']}', tr_introducao='$intro'";
    mysqli_query($conn, $sql);
}

?>
<!DOCTYPE html>
<html lang="pt-br">
    <head>
    <!-- Meta tags Obrigatórias -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../css/bootstrap.min.css">

    <title>Introdução</title>
    </head>
<body>
    <header class="d-print-none">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="mt-3 mb-2 text-center">
                        <a href="../tcc.php" class="btn btn-outline-info">Voltar</a>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <main>
        <section>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <?php
                        echo $intro;
                        ?>
                    </div>
                </div>
            </div>
        </section>
    </main>
</body>
</html>