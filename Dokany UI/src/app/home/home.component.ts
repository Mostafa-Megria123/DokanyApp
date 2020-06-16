import { Component, OnInit } from '@angular/core';
import "owl.carousel";
declare let $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  ngOnInit() {

    $(document).ready(function () {
      var owl = $('.owl-carousel');
      var navbarHead = $('.navbarHead').height();

      owl.owlCarousel({
        items: 4,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 1000,
        autoplayHoverPause: true
      });
      $('.play').on('click', function () {
        owl.trigger('play.owl.autoplay', [1000])
      });
      $('.stop').on('click', function () {
        owl.trigger('stop.owl.autoplay')
      });

      // $("html").mouseover(function () {
      //   $("html").getNiceScroll().resize();
      // });

      var setScroll = function (i) {
        if ($(i).length > 0)
          $(i).niceScroll().updateScrollBar();
      }
      setScroll(".classWithNiceScroll");

      $(window).scroll(function () {

        if ($(this).scrollTop() > navbarHead) {
          $('.navSection').addClass('fixed');
        } else {
          $('.navSection').removeClass('fixed');
        }
      });
    });
  }

}
