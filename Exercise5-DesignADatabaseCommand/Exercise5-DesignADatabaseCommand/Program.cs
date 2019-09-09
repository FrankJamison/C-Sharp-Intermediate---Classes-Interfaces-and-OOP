﻿using System;

namespace Exercise5_DesignADatabaseCommand
{
    /*
     * Design a class called DbCommand for executing an instruction against the database.
     * A DbCommand cannot be in a valid state without having a connection.
     * So in the constructor of this class, pass a DbConnection.
     * Don’t forget to cater for the null.
     *
     * Each DbCommand should also have the instruction to be sent to the database.
     * In case of SQL Server, this instruction is expressed in T-SQL language.
     * Use a string to represent this instruction.
     * Again, a command cannot be in a valid state without this instruction.
     * So make sure to receive it in the constructor and cater for the null reference or an empty string.
     *
     * Each command should be executable.
     * So we need to create a method called Execute().
     * In this method, we need a simple implementation as follows:
     *
     * Open the connection
     * Run the instruction
     * Close the connection
     *
     * Note that here, inside the DbCommand, we have a reference to DbConnection.
     * Depending on the type of DbConnection sent at runtime, opening and closing a connection will be different.
     * For example, if we initialize this DbCommand with a SqlConnection,
     * we will open and close a connection to a Sql Server database.
     * This is polymorphism.
     * Interestingly, DbCommand doesn’t care about how a connection is opened or closed.
     * It’s not the responsibility of the DbCommand.
     * All it cares about is to send an instruction to a database.
     *
     * For running the instruction, simply output it to the Console.
     * In the real-world, SQL Server (or any other DBMS) provides an API for running an instruction against the database.
     * We don’t need to worry about it for this exercise.
     *
     * In the main method, initialize a DbCommand with some string as the instruction and a SqlConnection.
     * Execute the command and see the result on the console.
     *
     * Then, swap the SqlConnection with an OracleConnection and see polymorphism in action.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Exception handling test
            var sqlConnectionTest = new SqlConnection(null);

            // Create a valid SQL database connection
            var sqlConnection = new SqlConnection("Connection to SQL Server");

            // Exception Handling tests
            var sqlInstructionTest1 = new DbCommand(sqlConnection, " ");
            var sqlInstructionTest2 = new DbCommand(null, "SQL Command");
            var sqlInstructionTest3 = new DbCommand(null, "");

            // Create a valid SQL database command
            var sqlCommand = new DbCommand(sqlConnection, "SQL Command");

            // Execute the SQL command
            sqlCommand.Execute();

            // Create a valid Oracle database connection
            var oracleConnection = new OracleConnection("Connection to Oracle server");

            // Create a valid Oracle database command
            var oracleCommand = new DbCommand(oracleConnection, "Oracle Command");

            // Execute the Oracle command
            oracleCommand.Execute();


        }
    }
}
