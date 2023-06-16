﻿namespace RestaurantReviewPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewrestaurantid : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reviews", "RestaurantId");
            AddForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
        }
    }
}
