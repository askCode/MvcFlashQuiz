namespace FlashQuiz_2ndAttempt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizName = c.String(),
                        QuizTopic = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        WrongAnswer1 = c.String(),
                        WrongAnswer2 = c.String(),
                        WrongAnswer3 = c.String(),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.QuizQuestions", new[] { "QuizId" });
            DropForeignKey("dbo.QuizQuestions", "QuizId", "dbo.Quizs");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.Quizs");
        }
    }
}
