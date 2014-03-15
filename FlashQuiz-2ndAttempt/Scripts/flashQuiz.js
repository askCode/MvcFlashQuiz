//Receive JSON data with questions/answers as a parameter
function Quiz(questions) {

    var correct = 0;
    var incorrect = 0;
    var i = 0;
    var $progress = $('#progressbar');
    var $progresscomplete = $('#progress');

    Highlighter();
    NextQuestion();
    $('#correct').html(correct);
    $('#incorrect').html(incorrect);


    //
    function Check() {
        if (i < questions.length) {
            $(this).removeClass('highlight');
            if ($(this).hasClass('correctanswer')) {
                correct++;
                $('#correctalert').show('slide').delay(300).hide('slide');
                $(this).toggleClass('correcthighlight');
            }
            else {
                incorrect++;
                $('#incorrectalert').html('<p class="text-primary">Sorry!</p><p class="text-info">Correct Answer: </p><p class="text-info">' + questions[i].Correct + '</p>').show('slide').delay(3000).hide('slide');
                $('.correctanswer').toggleClass('correcthighlight');
                $(this).toggleClass('incorrecthighlight');

            }
            i++;
            var temp = ((i / questions.length) * 100) + '%';
            $progress.attr('aria-valuenow', i).attr('aria-valuemax', questions.length).css('width', temp);
            $progresscomplete.html(temp);
            //Disable click events
            $('td').off('click');
            $('#correct').html(correct);
            $('#incorrect').html(incorrect);
            setTimeout(NextQuestion, 400);
        }
    }

    //Loads the next set of questions/answers
    function NextQuestion() {
        //Enable click events
        $('td').on('click', Check);
        $('td').removeClass('correcthighlight').removeClass('incorrecthighlight');

        //Check if there are still questions
        if (i < questions.length) {
            $('#questioncontent').html(questions[i].Question);
            AnswerSort();
        }

            //Return screen at end of quiz
        else {
            if (correct > incorrect) {
                $('#completionmessage').html('<h3 class="text-success">Congratulations!</h1>');
            }
            else {
                $('#completionmessage').html('<h3 class="text-primary">Better luck next time!</h1>');
            }
            $('#correctresult').html(correct);
            $('#incorrectresult').html(incorrect);
            var correctpercent = ((correct / (correct + incorrect)) * 100) + '%';
            var incorrectpercent = ((incorrect / (correct + incorrect)) * 100) + '%';
            $('#finalpercent').html(correctpercent);
            $('#correctpercentage').html(correctpercent);
            $('#incorrectpercentage').html(incorrectpercent);
            $('#quizform').fadeOut(1000);
            $('#footer').fadeOut(1000);
            $('#completion').delay(1000).fadeIn("slow");
            $('#correctbar').attr('aria-valuenow', correct).attr('aria-valuemax', questions.length).css('width', correctpercent);
            $('#incorrectbar').attr('aria-valuenow', incorrect).attr('aria-valuemax', questions.length).css('width', incorrectpercent);
            $('#')
        }

        //Randomize question locations
        function AnswerSort() {
            var $A = $('#A');
            var $B = $('#B');
            var $C = $('#C');
            var $D = $('#D');
            $A.html('');
            $B.html('');
            $C.html('');
            $D.html('');
            CorrectPlace(questions[i].Correct);
            WrongPlace(questions[i].Wrong1);
            WrongPlace(questions[i].Wrong2);
            WrongPlace(questions[i].Wrong3);

            //Places the correct answer and uses jQuery to add the correctanswer clas to the parent
            function CorrectPlace(answer) {
                switch (Math.floor((Math.random() * 4 + 1))) {
                    case 1:
                        if (isEmpty($A)) {
                            $A.html(answer);
                            $A.parent('td').addClass('correctanswer');
                        }
                        else {
                            CorrectPlace(answer);
                        }
                        break;

                    case 2:
                        if (isEmpty($B)) {
                            $B.html(answer);
                            $B.parent('td').addClass('correctanswer');
                        }
                        else {
                            CorrectPlace(answer);
                        }
                        break;

                    case 3:
                        if (isEmpty($C)) {
                            $C.html(answer);
                            $C.parent('td').addClass('correctanswer');
                        }
                        else {
                            CorrectPlace(answer);
                        }
                        break;

                    case 4:
                        if (isEmpty($D)) {
                            $D.html(answer);
                            $D.parent('td').addClass('correctanswer');
                        }
                        else {
                            CorrectPlace(answer);
                        }
                        break;
                }
            }

            //Places the wrong answers and uses jQuery to remove the correctanswer class
            //from the parent if it contains it from a previous question
            function WrongPlace(answer) {
                switch (Math.floor((Math.random() * 4 + 1))) {
                    case 1:
                        if (isEmpty($A)) {
                            $A.html(answer);
                            $A.parent('td').removeClass('correctanswer');
                        }
                        else {
                            WrongPlace(answer);
                        }
                        break;

                    case 2:
                        if (isEmpty($B)) {
                            $B.html(answer);
                            $B.parent('td').removeClass('correctanswer');
                        }
                        else {
                            WrongPlace(answer);
                        }
                        break;

                    case 3:
                        if (isEmpty($C)) {
                            $C.html(answer);
                            $C.parent('td').removeClass('correctanswer');
                        }
                        else {
                            WrongPlace(answer);
                        }
                        break;

                    case 4:
                        if (isEmpty($D)) {
                            $D.html(answer);
                            $D.parent('td').removeClass('correctanswer');
                        }
                        else {
                            WrongPlace(answer);
                        }
                        break;
                }

            }

            function isEmpty(element) {
                return !$.trim(element.html());
            }
        }
    }

    //Simple hover-toggle highliht
    function Highlighter() {
        $('td').mouseenter(function () {
            $(this).addClass('highlight');
        })
        $('td').mouseleave(function () {
            $(this).removeClass('highlight');
        })
    }
}