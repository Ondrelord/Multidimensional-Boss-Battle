﻿/* MIT License
Copyright (c) 2016 RedBlueGames
Code written by Doug Cox
*/

using System;
using UnityEngine;

/// <summary>
/// GitException includes the error output from a Git.Run() command as well as the
/// ExitCode it returned.
/// </summary>
public class GitException : InvalidOperationException
{
    public GitException(int exitCode, string errors) : base(errors) =>
        this.ExitCode = exitCode;

    /// <summary>
    /// The exit code returned when running the Git command.
    /// </summary>
    public readonly int ExitCode;
}

public static class Git
{
    /* Properties ============================================================================================================= */

    /// <summary>
    /// Retrieves the build version from git based on the most recent matching tag and
    /// commit history. This returns the version as: {major.minor.build} where 'build'
    /// represents the nth commit after the tagged commit.
    /// Note: The initial 'v' and the commit hash code are removed.
    /// </summary>
    public static string BuildVersion
    {
        get
        {
            var version = Run(@"describe --tags --long --match ""v[0-9]*""");
            // Remove initial 'v' and ending git commit hash.
            version = version.Replace('-', '.');
            version = version.Substring(1, version.LastIndexOf('.') - 1);
            return version;
        }
    }

    /// <summary>
    /// The currently active branch.
    /// </summary>
    public static string Branch => Run(@"rev-parse --abbrev-ref HEAD");

    /// <summary>
    /// Returns a listing of all uncommitted or untracked (added) files.
    /// </summary>
    public static string Status => Run(@"status --porcelain");

    /// <summary>
    /// Checks for differences.
    /// </summary>
    public static string Diff => Run(@"diff");

    /// <summary>
    /// Adding all changes.
    /// </summary>
    public static string Add => Run(@"add .");

    /// <summary>
    /// Commits changes with message.
    /// </summary>
    public static string Commit => Run(@"commit");

    /// <summary>
    /// Commits changes with message.
    /// </summary>
    public static string QuickCommit => Run(@"commit -m " + "\"QC of " + BuildVersion + "\"");

    /// <summary>
    /// Commits changes with message.
    /// </summary>
    public static string Tag(string tag, string massage) => Run(@"tag -a " + tag + " -m '" + massage + "'");

    /// <summary>
    /// Pushing to git.
    /// </summary>
    public static string Push => Run(@"push");

    /// <summary>
    /// Pushing to git.
    /// </summary>
    public static string PushTags => Run(@"push --tags");

    //TODO: Fetch, Pull etc;


    /* Methods ================================================================================================================ */

    /// <summary>
    /// Runs git.exe with the specified arguments and returns the output.
    /// </summary>
    public static string Run(string arguments)
    {
        using (var process = new System.Diagnostics.Process())
        {
            var exitCode = process.Run(@"git", arguments, Application.dataPath,
                out var output, out var errors);

            process.WaitForExit();

            if (exitCode == 0)
            {
                return output;
            }
            else
            {
                return errors;
                throw new GitException(exitCode, errors);
            }
        }
    }
}
