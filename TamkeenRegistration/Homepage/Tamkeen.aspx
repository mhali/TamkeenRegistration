﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tamkeen.aspx.cs" Inherits="TamkeenRegistration.Homepage.Tamkeen" %>



<!DOCTYPE html>
<!-- saved from url=(0019)https://tamkeen.us/ -->
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">


    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Tamkeen</title>
<%--    <link rel="shortcut icon" href="https://tamkeen.us/static/images/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="https://tamkeen.us/static/images/favicon.ico" type="image/x-icon" />--%>

    <!-- Bootstrap Core CSS -->
    <link href="./Tamkeen_files/bootstrap.min.css" rel="stylesheet" />

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="./Tamkeen_files/bootstrap.min(1).css" />

    <!-- Theme CSS -->
    <link href="./Tamkeen_files/styles.css" rel="stylesheet" />
    <link href="./Tamkeen_files/question.css" rel="stylesheet" />

        <link rel="stylesheet" href="./Tamkeen_files/product-list-vertical.css"/>
    <link rel="stylesheet" href="./Tamkeen_files/image-list-basic.css"/>
    <link rel="stylesheet" href="./Tamkeen_files/product-list-basic.css"/>
    <link rel="stylesheet" href="./Tamkeen_files/animate.css"/>
    <link href="./Tamkeen_files/videos.css" rel="stylesheet"/>
    <!-- Custom Fonts -->
    <link href="./Tamkeen_files/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href="./Tamkeen_files/css" rel="stylesheet" type="text/css"/>
    <link href="./Tamkeen_files/css(1)" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />

  

</head>


<body id="page-top" class="index">
<%--<a name="top"></a>--%>

    <!-- Navigation -->
    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top navbar-custom">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand" href="Tamkeen.aspx">Tamkeen</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <form runat="server">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="hidden">
                            <a href="Tamkeen.aspx"></a>
                        </li>
                        <!-- <li class="page-scroll">
                        <a href="/events/">Events</a>
                    </li> -->
                        <li class="page-scroll">
                            <a href="Videos.aspx">Videos</a>
                            <%--<a href="https://tamkeen.us/videos/">Videos</a>--%>
                        </li>
                        <li class="page-scroll">
                            <a href="openyourheart.aspx">
                                <img src="./Tamkeen_files/openyourheart.png" alt="" width="20px">
                                Open Your Heart</a>
                        </li>
                        <!-- <li class="page-scroll">
                        <a href="/books/">Library</a>
                    </li> -->
                        <li class="page-scroll">
                            <a href="quiz.aspx">Weekly Quiz</a>
                        </li>
                        <li class="dropdown">
                            <button href="#" class="dropdown-toggle dropdown-button" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">About <span class="caret"></span></button>
                            <ul class="dropdown-menu page-scroll" role="menu">
                                <li><a href="#mission">Our Mission</a></li>
                                <li><a href="#strategy">Our Strategy</a></li>
                                <li><a href="#partners">Our Partners</a></li>
                                <li><a href="#organization">Our Organizational Structure</a></li>
                                <%--<li><a href="https://tamkeen.us/static/Non-profit-bylaws.docx.pdf">Our ByLaws</a></li>--%>
                            </ul>
                        </li>

<%--                        <li class="page-scroll">
                            <a href="https://tamkeen.us/accounts/login">Sign In</a>

                        </li>--%>
<%--                        <li class="page-scroll" style="background-color: red">
                            <a href="~/../../CreateUser/CreateUser.aspx">Sign up</a>
                        </li>--%>
                        <li>
                            <asp:LinkButton ID="btnSignUp" runat="server" Text="SignUp" OnClick="btnSignUp_Click" />
                        </li>
                        <li>
                            <asp:LinkButton ID="lblNickName" runat="server" Text="" fontsize="20px" OnClick="lblNickName_Click"/>
                        </li>
                        <!-- <li class="page-scroll">
                        <a href="#contact">Contact</a>
                    </li> -->
                    </ul>
                </form>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>








       <header class="parallax">
         <div class="cycle-slideshow bg" data-cycle-speed="1000" width="100%">
            <img src="./Tamkeen_files/khalidibnwaleedpichalaqa.jpg" class="cycle-slide cycle-sentinel" style="position: static; top: 0px; left: 0px; z-index: 100; opacity: 1; display: block; visibility: hidden;">
            <img src="./Tamkeen_files/khalidibnwaleedpichalaqa.jpg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 94; opacity: 0; display: block; visibility: hidden;">
            <img src="./Tamkeen_files/bg.jpg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 93; visibility: hidden; opacity: 0; display: block;">
            <img src="./Tamkeen_files/bg1.jpg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 100; visibility: hidden; opacity: 0; display: block;">
            <img src="./Tamkeen_files/bg5.jpg" class="cycle-slide cycle-slide-active" style="position: absolute; top: 0px; left: 0px; z-index: 99; visibility: visible; opacity: 1; display: block;">
            <img src="./Tamkeen_files/tamkeenGroupLunch.jpeg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 97; visibility: hidden; opacity: 0; display: block;">
            <img src="./Tamkeen_files/tamkeen-battleofyarmookpichalaqa.jpg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 96; visibility: hidden; opacity: 0; display: block;">
            <img src="./Tamkeen_files/football.jpg" class="cycle-slide" style="position: absolute; top: 0px; left: 0px; z-index: 95; visibility: hidden; opacity: 0; display: block;">
        </div>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <img class="img-responsive animated flipInX" src="./Tamkeen_files/logo.png" alt="">
                    <div class="intro-text">
                        <!-- <span class="name animated slideInRight">تمكيــــــــــــن</span>
                        <span class="name animated slideInLeft">TAMKEEN</span> -->
                        <span class="name">BUILDING A MUSLIM</span><br>


                        <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top" class="btn  hvr-bounce-in">
                            <input type="hidden" name="cmd" value="_s-xclick">
                            <input type="hidden" name="hosted_button_id" value="5DTHYHPL9LEPN">
                            <input type="image" class="paypalbutton" src="./Tamkeen_files/paypal-donate-button1.png" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
                            <img alt="" border="0" src="./Tamkeen_files/pixel.gif" width="1" height="1">
                        </form>
                        <br>
                    </div>
                </div>
            </div>
        </div>
       </header>
    <div>
    <section id="mailingList" class="white">
        <div class="container">

            <h3 class="text-center">Want to stay up to date, Join our mailing lists</h3>
            <hr class="star-primary">
            <div class="row">
                <div class="col-md-4 text-center">
                    <!-- <a href="https://groups.google.com/forum/#!forum/tamkeen-boys/join" class="btn-hover color-6 register hvr-pop" role="button" target="_blank">Tamkeen Boys</a> -->
                    <a href="https://groups.google.com/forum/#!forum/tamkeen-boys/join" target="_blank">
                        <button class="btn-hover color-1 hvr-push">Tamkeen Boys</button></a>
                </div>
                <div class="col-md-4 text-center">
                    <!-- <a href="https://groups.google.com/forum/#!forum/tamkeen-girls/join" class="btn btn-custom register hvr-pop" role="button" target="_blank">Tamkeen Girls</a> -->
                    <a href="https://groups.google.com/forum/#!forum/tamkeen-girls/join" target="_blank">
                        <button class="btn-hover color-10 hvr-push">Tamkeen Girls</button></a>
                </div>
                <div class="col-md-4 text-center">
                    <!-- <a href="https://groups.google.com/forum/#!forum/tamkeen-parents/join" class="btn btn-danger register hvr-pop" role="button" target="_blank">Tamkeen Parents</a> -->
                    <a href="https://groups.google.com/forum/#!forum/tamkeen-parents/join" target="_blank">
                        <button class="btn-hover color-2 hvr-push">Tamkeen Parents</button></a>
                </div>
            </div>
        </div>
    </section>

    <section id="suggestedVideo" class="blue">
        <div class="container">
            <h2 class="text-center">Suggested Videos</h2>
            <hr class="star-primary">
            <div class="row">
                <div class="col-sm text-center">
                    <iframe id="suggestedVideo1" width="400" height="200" src='' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen runat="server"></iframe>
                    <br />
                    <asp:Label ID="lblsuggestedVideo1" runat="server" Text="" Enabled="false"></asp:Label>
                    <br />
                    <br />
                    <iframe id="suggestedVideo2" width="400" height="200" src='' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen runat="server"></iframe>
                    <br />
                    <asp:Label ID="lblsuggestedVideo2" runat="server" Text="" Enabled="false"></asp:Label>
                    <br />
                    <br />

                    <%--        <div class="youtube" data-embed="b4HdVzQxVLA" data-videoid="123">
            <div class="topcorner" style="font-size:2em;">
              <i class="fa fa-fw fa-eye"></i>
              11
            </div>
            <div class="play-button"></div>
        <img src="./Tamkeen_files/sddefault.jpg"></div>
        <p>
          The Ayah of Ramadan - Part 1
        </p>
      
        <div class="youtube" data-embed="R-Van5IiVTI" data-videoid="122">
            <div class="topcorner" style="font-size:2em;">
              <i class="fa fa-fw fa-eye"></i>
              12
            </div>
            <div class="play-button"></div>
        <img src="./Tamkeen_files/sddefault(1).jpg"></div>
        <p>
          Journey with Quran: Revision tips by Sheikh Yahya Al-Raaby. One of your goals in Ramadan is to memorize and review the Quran right? Well here are tips to review and memorize the Quran better. And Inshallah you continue to be consistent with reviewing and memorizing Quran during and after Ramadan.
        </p>
      
      </div>--%>
                </div>
            </div>
    </section>

    <section class="white" id="mission">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>Our Mission</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-lg-offset-2">
                    <p>We believe that raising a healthy family is a community responsibility. And it must start with our children. At TAMKEEN we focus our full attention and effort on building strong young Muslims boys and girls. </p>
                </div>
                <div class="col-lg-4">
                    <p>We believe that children are like plants: If you over-water them, they will yellow and die but you also can’t underwater them or nothing will come to fruition. You have to help the plant/child along by gently guiding and often letting it get a little wild for the best results.</p>
                </div>

            </div>
        </div>
    </section>

    <section class="blue" id="strategy">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>Our Strategy</h2>
                    <hr class="star-primary">
                    <img src="./Tamkeen_files/logo.png" alt="" width="100" style="margin: 10px">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">

                    <blockquote>
                        <p>
                            “Indeed there is a tree that does not shed its leaves, it resembles a Muslim. So tell me, which is it?”
                  So people started discussing the trees of the country side. ‘Abdullaah ibn ‘Umar said:

                  “I thought to myself that it was the date palm tree, but I was shy [and did not speak up].”

                  So they asked the Messenger – صَلَّى اللَّه عَلَيْهِ وَسَلَّمَ: “Tell us what it is O Messenger of Allah.”
                  He said: “It is the date palm tree.” The Messenger of Allah (ﷺ)
                        </p>
                    </blockquote>

                    <p>
                        This beautiful saying of the prophet inspired us to design our logo as well as defining our strategy. At TAMKEEN, we believe that there are five important qualities a Muslim should strive to attain.
                    </p>
                </div>
            </div>
            <br>
            <div class="row">
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="./Tamkeen_files/heart.png" alt="..." width="100px">
                        <div class="caption">
                            <h3 style="text-align: center">Pure Heart</h3>
                            <p>The Prophet salallaahu ‘alayhi wa sallam said about your heart: Truly in the body there is a morsel of flesh which, if it be sound, all the body is sound and which, if it be diseased, all of it is diseased. Truly it is the heart. At TAMKEEN, Helping our children to have a pure and caring heart is one of our first priorities</p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="./Tamkeen_files/brain.png" alt="..." width="100px">
                        <div class="caption">
                            <h3 style="text-align: center">Wisdom</h3>
                            <p>In order to start moving in life you first need to have knowledge; with that knowledge you can define if something is important or not. Then it is up to you to make the move. Our Islamic studies classes help student understand Islam more to help them take wiser decisions in life</p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="./Tamkeen_files/body.png" alt="..." width="100px">
                        <div class="caption">
                            <h3 style="text-align: center">Strong Body</h3>
                            <blockquote>
                                <p style="text-align: center">"The strong believer is better and more beloved to Allah than the weak believer". Prophet (pbuh) </p>
                            </blockquote>
                            <p>At TAMKEEN, We plan a variety of physical activities in which our young boys and girls have the chance to play in a fun and safe environment and get stronger everyday</p>
                        </div>
                    </div>
                </div>



                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="./Tamkeen_files/team.png" alt="..." width="100px">
                        <div class="caption">
                            <h3 style="text-align: center">Teamwork</h3>
                            <blockquote>
                                <p style="text-align: center">"And hold firmly to the rope of Allah all together and do not become divided." Surat Ali 'Imran [verse 103]    </p>
                            </blockquote>
                            <p>Teamwork is the oil that makes the team work. It can enable smoother movement towards targets, can prolong forward momentum, and can help teams to overcome obstacles. Allah commanded the believers in many verses in the Quran to be united and act as one.</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="./Tamkeen_files/fun.png" alt="..." width="100px">
                        <div class="caption">
                            <h3 style="text-align: center">Fun</h3>
                            <p>Kids learn to best when they are having fun and are actively engaged as they observe more. Lots of research underline the importance of play, especially in the early years. Our fun activities will help the children engage with each other, improve their social skills and enhance their brain capabilities.</p>
                        </div>
                    </div>
                </div>
            </div>


            <br>
        </div>
    </section>

    <section class="white" id="partners">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>Our Partners</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-lg-offset-2" style="text-align: center">
                    <img src="./Tamkeen_files/ymca.png" alt="...">
                </div>
                <div class="col-lg-4">
                    <p>Most of TAMKEEN indoor activities are sponsored by the <a href="https://www.northshoreymca.org/">Northshore YMCA </a>. Usually, we run all the activities Saturdays afternoon right after the TAMKEEN halaqa. YMCA provides a place full of opportunities for kids to develop into smart resilient adults, and to improve their health. Whether its basketball or indoor soccer, whether it is a movie night or a cooking class, the YMCA has been the home of many of these activities.</p>
                </div>

            </div>
            <br>
            <br>
            <div class="row">
                <div class="col-lg-4 col-lg-offset-2 vertical-center" style="align-items: center">
                    <img class="learningForLifeLogo" src="./Tamkeen_files/learning-logo.png" alt="...">
                </div>
                <div class="col-lg-4">
                    <p>TAMKEEN partners with Boys Scout of America to bring the "Learning for Life (LFL)" program to our youth (boys and girls 10 years old and up to 21). Boys Scout of America provides training to our volunteers, provides resources, and covers our activities with its "Comprehensive General Liability Insurance". This coverage provides protection for the LFL office, all LFL professionals and employees, Explorer posts or LFL groups, participating organizations, and volunteer adult participants with respect to claims arising in the performance of their duties in LFL.</p>
                    <p>Each child is supposed to fill an application before participating in any of TAMKEEN activities</p>

                </div>
            </div>


        </div>
    </section>

    <section class="blue" id="organization">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>Our Organizational Strucure</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <blockquote>
                        <p>When three persons set out on a journey, they should appoint one of them as their leader. The Messenger of Allah (ﷺ)</p>
                    </blockquote>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-lg-offset-2 text-center">
                    <img src="./Tamkeen_files/organization.png">
                </div>
                <div class="col-lg-4 ">
                    <p>In order to improve the productivity and motivation of TAMKEEN youth in all the five dimensions mentioned above ( Heart, Wisdom, Body, Teamwork and Fun ), we make sure that our youth are assembled into small teams. Each team consists of six members with one leader. The leader's responsibility is to advance each team member spiritually, physically and socially. More specifically, the team leader' responsibility is (1) to monitor the attendance and participation of team members, (2) to advise and correct the behavior within the team (3) to improve communication among team members, (4) to facilitate communication across teams, and (5) to transfer leadership skills to other members.</p>

                    <p>Creating small groups includes: Improves morale and leadership skills, Finds the barriers that thwart creativity, Clearly defines objectives and goals, Improves processes and procedures, Improves organizational productivity, Identifies team's strengths and weaknesses and Improves the ability to solving problems.</p>
                </div>
                <div class="col-lg-8 col-lg-offset-2 text-center">
                </div>
            </div>
        </div>
    </section>

    <script>
        var youtube = document.querySelectorAll(".youtube");
        for (var i = 0; i < youtube.length; i++) {

            var source = "https://img.youtube.com/vi/" + youtube[i].dataset.embed + "/sddefault.jpg";

            var image = new Image();
            image.src = source;
            image.addEventListener("load", function () {
                youtube[i].appendChild(image);
            }(i));

            youtube[i].addEventListener("click", function () {

                var iframe = document.createElement("iframe");

                iframe.setAttribute("frameborder", "0");
                iframe.setAttribute("allowfullscreen", "");

                iframe.setAttribute("src", "https://www.youtube.com/embed/" + this.dataset.embed + "?rel=0&showinfo=0&autoplay=1");

                this.innerHTML = "";
                this.appendChild(iframe);

                data = {
                    videoId: this.dataset.videoid
                };

                $.ajax({
                    type: "POST",
                    url: "/api/video/play/",
                    data: JSON.stringify(data),
                    error: function (xhr, status, error) {
                        console.log(xhr.responseText);
                    }
                });

            });
        }

    </script>
    
    </div>









    <!-- Footer -->
    <footer class="text-center">
        <div class="footer-above">
            <div class="container">
                <div class="row">
                    <div class="footer-col">
                        <h3>Around the Web</h3>
                        <ul class="list-inline">
                            <li>
                                <a href="https://www.facebook.com/tamkeenyouth/" class="btn-social btn-outline hvr-pop" target="_blank"><i class="fa fa-fw fa-facebook"></i></a>
                            </li>
                            <li>
                                <a href="https://www.youtube.com/TamkeenYouth" class="btn-social btn-outline hvr-pop" target="_blank"><i class="fa fa-fw fa-youtube"></i></a>
                            </li>
                            <li>
                                <a href="https://www.instagram.com/tamkeenyouth" class="btn-social btn-outline hvr-pop" target="_blank"><i class="fa fa-fw fa-instagram"></i></a>
                            </li>
                        </ul>
                        <div class="page-scroll">
                            <a href="#top">
                                <img style="width: 100px; margin: 0 auto;" class="img-responsive hvr-push" src="./Tamkeen_files/logo.png" alt=""></a>
                            <p>Go Back Up</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-below">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        Copyright © Tamkeen 2017
                    </div>
                </div>
            </div>
        </div>
    </footer>


  <%--  <div class="scroll-top page-scroll hidden-sm hidden-xs hidden-lg hidden-md">
        <a class="btn btn-primary" href="~/#page-top">
            <i class="fa fa-chevron-up"></i>
        </a>
    </div>--%>

    <script src="./Tamkeen_files/jquery.min.js"></script>
    <script src="./Tamkeen_files/jquery.cycle2.min.js"></script>
    <script src="./Tamkeen_files/bootstrap.min.js"></script>
    <script src="./Tamkeen_files/jquery.easing.min.js"></script>
    <script src="./Tamkeen_files/jqBootstrapValidation.js"></script>
    <script src="./Tamkeen_files/main.js"></script>








</body>
</html>
