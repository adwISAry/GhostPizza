﻿using GhostPizza.Core.Models;
using GhostPizza.InfraStructure.Exceptions;

namespace GhostPizza.InfraStructure.Services
{
	public static class UserService
	{
		public static void AddUser(User user)
		{
			DataBase.Users.Add(user);
		}

		public static void RemoveUser(int id)
		{
			DataBase.Users.Remove(GetUserById(id));
		}

		public static void UpdateUserRole(int id, UserType newUserType)
		{
			GetUserById(id).UserType = newUserType;
		}

		public static User GetUserById(int id)
		{
			var user = DataBase.Users.Find(user => user.Id == id);
			if (user != null)
			{
				return user;
			}
			else
			{
				throw new UserNotFoundException("User not found.");
			}
		}

		public static void UsernameCheck(string username)
		{
			if (DataBase.Users.Any(user => user.UserName == username))
			{
				throw new UsernameAlreadyExistsException("Username is already taken. Please choose a different username.");
			}
		}

		public static List<User> GetAllUsers()
		{
			return DataBase.Users;
		}
	}
}
