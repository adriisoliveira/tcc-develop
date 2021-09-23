<!DOCTYPE html>
<?php
	//PARA FUNCIONAR A VARIAVEL GLOBAL LA EM BAIXO, A SESSAO DEVE SER A PRIMEIRA COISA A SER INICIALIZADA
	SESSION_START();
	
?>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>FRN-Formatação Rápida nas Normas</title>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet">

    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="style.css">
    <link rel="stylesheet" href="responsive.css">
    <style type="text/css">
    body {
	background-color: #fff;
}
    </style>
</head>

<body 
    <div class="wrapper">
        <header class="header">
            <section class="header-top">
                <div class="container">
                    <div class="row">
                        <div class="col-md-8 col-sm-8 col-xs-12">
                            <div class="contact">
                                
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="join-us">
							<?php if(isset($_SESSION['logado'])){	?>
								<p><a href="FormatacaoTCC/tcc.php">FORMATE AQUI SEU TCC !!</a></p>
						<?php 	}
						else{ ?>
							<p><a href="../../tcc/login.php">FORMATE AQUI SEU TCC !!</a></p>
							<?php 	} ?>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="header-bottom">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5 col-sm-12 col-xs-12">
                            <a href="#">
                                <div class="main-logo">
                                    <img src="img\img29\logonova.jpg" alt="">
                            
                                </div>
                            </a>
                        </div>
                        <div class="col-md-7 col-sm-12 col-xs-12">
                            <div class="menu">
                                <ul class="nav navbar-nav">
                                   
                                
                                    
                                    <li><a href="modelosabnt.html">MODELOS NAS NORMAS ABNT</a></li>
                                    <li><a href="dicasdeword.html">DICAS DE WORD</a></li>
                                    <li><a href="dicasdeverbtex.html">DICAS DO VERBTEX </a></li>                                    
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </header>
        <section class="carosal-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="client owl-carousel owl-theme">
                            <div class="item">
                                <div class="text">
                                    <h3>FRN - Formatação Rápida nas Normas</h3>
                                    <p> Neste site você encontrará de tudo para facilitar sua vida na hora de colocar seu trabalho nas normas ABNT. Como modelos prontos para você modificar e dicas de como usar o word e o verbtex, além de que aqui você pode formatar seu TCC sem grandes dificuldades apenas seguindo o tutorial.</p>
                                    <h5 class="white-button"><a href="login.php">Formate aqui seu TCC!!!</a></h5>
                                    
                                    
                                </div>
                            </div>
                            <div class="item">
                                <div class="text">
                                    <h3>Formatação do seu TCC</h3>
                                    <p> Com a FRN se tornou muito mais fácil a formatação do seu TCC. Tudo que você precisa saber é alguns conceitos básicos de html e de um conversor para PDF que estará tudo explicado no tutorial.</p>
                                    <h5 class="white-button"><a href="#">Formate aqui seu TCC!!!</a></h5>
                                    
                                </div>
                            </div>
                            <div class="item">
                                <div class="text">
                                    <h3>Modelos nas normas ABNT</h3>
                                    <p>Para facilitar a produção do seu trabalho a FRN disponibiliza alguns modelos de artigos, monografias, TCC's e documentos simples para modificação rápida.</p>
                                    <h5 class="white-button"><a href="#">MODELOS</a></h5>
                                    
                                </div>
                            </div>
                            <div class="item">
                                <div class="text">
                                    <h3>Dicas de Word e de VerbTex</h3>
                                    <p> Caso você tenha duvidas em algumas funções do Word e do VerbTex, a FRN disponibiliza tutoriais simples e completos de como usar essas ferramentas.  </p>
                                    <h5 class="white-button"><a href="#">WORD</a></h5>
                                    <h5 class="white-button"><a href="#">VERBTEX</a></h5>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="our_activity">
            <h2>FRN - Formatação Rápida nas Normas</h2>
            <div class="tabata"><p>Neste site você encontrará de tudo para facilitar sua vida na hora de colocar seu trabalho nas normas ABNT. Como modelos prontos para você modificar e dicas de como usar o word e o verbtex, além de que aqui você pode formatar seu TCC sem grandes dificuldades. </p></div>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-xs-12">
                        <div class="single-Promo">
                            <div class="promo-icon">
                                <i class="material-icons">near_me</i>
                            </div>
                            <h2><a href="#">Modelos nas normas ABNT</a></h2>
                            <p>Para facilitar a produção do seu trabalho a FRN disponibiliza alguns modelos de artigos, monografias, TCC's e documentos simples para modificação rápida. </p>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="single-Promo">
                            <div class="promo-icon">
                                <i class="material-icons">favorite</i>
                            </div>
                            <h2><a href="#">Formatação do seu TCC</a></h2>
                            <p>Com a FRN se tornou muito mais fácil a formatação do seu TCC. Ele estará formatado conforme você preencha o formulário. </p>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="single-Promo">
                            <div class="promo-icon">
                                <i class="material-icons">dashboard</i>
                            </div>
                            <h2><a href="#">Dicas de Word e de VerbTex</a></h2>
                            <p>Caso você tenha duvidas em algumas funções do Word e do VerbTex, a FRN disponibiliza tutoriais simples e completos de como usar essas ferramentas.  </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    

      


        <footer class="footer">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-12">
                        <div class="footer-charity-text">
                            <h2>SOBRE</h2>
                            <p>Neste site você encontrará de tudo para facilitar sua vida na hora de colocar seu trabalho nas normas ABNT. Como modelos prontos para você modificar e dicas de como usar o word e o verbtex, além de que aqui você pode formatar seu TCC sem grandes dificuldades apenas seguindo o tutorial. </p>
                            <hr>
                            <p><a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a><a href="#"><i class="fa fa-behance" aria-hidden="true"></i></a><a href="#"><i class="fa fa-dribbble" aria-hidden="true"></i></a></p>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-4 col-sm-5">
                                <div class="footer-text one">
                                    <h3>PERGUNTAS</h3>
                                    <ul>
                                        <li><a href="#"><i class="material-icons">keyboard_arrow_right</i> Parceiros</a></li>
                                        <li><a href="#"><i class="material-icons">keyboard_arrow_right</i> ABNT NBR 12724 </a></li>
                                        
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-3">
                                <div class="footer-text two">
                                    <h3> LINKS ÚTEIS</h3>
                                    <ul>
                                        <li><a href="#">Home</a></li>
                                        <li><a href="#">Formate seu TCC</a></li>
                                        <li><a href="#">Tutorial de como formatar seu TCC</a></li>
                                        <li><a href="#">Modelos de trabalhos nas normas ABNT</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <div class="footer-text one">
                                    <h3>CONTATO</h3>
                                    <ul>
                                        <li><a href="#"><i class="material-icons">location_on</i> R. Alcântara, 113 - Vila Guilherme, São Paulo - SP, 02110-010</a> </li>
                                        <li><a href="#"><i class="material-icons">email</i>emaildereclamação@gmail.com</a></li>
                                        <li><a href="#"><i class="material-icons">call</i>+123456789</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer_bottom">
                <p>Copyright @ 2019 <a href="#">FRN</a> - Formatação Rápida nas Normas </p>
            </div>
        </footer>
    </div>
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/animationCounter.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/active.js"></script>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-36251023-1']);
        _gaq.push(['_setDomainName', 'jqueryscript.net']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script');
            ga.type = 'text/javascript';
            ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();
    </script>
</body>

</html>