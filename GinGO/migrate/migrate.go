package main

import (
	"aprenderGin/configs"
	"aprenderGin/models"
)

func init() {
	configs.ConnectToDB()
}

func main() {
	configs.DB.AutoMigrate(&models.Person{})
}