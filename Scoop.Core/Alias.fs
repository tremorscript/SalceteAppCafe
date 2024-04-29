namespace Scoop.Core

// Aliases are custom scoop subcommands that can be created to make common tasks
module Alias =

    // Adds an alias to a scoop subcommand
    // scoop alias add rm 'scoop uninstall $args[0]' 'Uninstalls an app'
    // scoop alias add upgrade 'scoop update *' 'Updates all apps, just like brew or apt'
    let add name subCommand description =
      ()

    // Removes an alias that was already added
    // scoop alias rm alias-name
    let remove name = 
      ()

    // Lists the aliases available or added by the user alias that is added
    //-v, --verbose   Show alias description and table headers (works only for 'list')
    let lists 
  (*

  Usage: scoop alias add|list|rm [<args>]

  Add, remove or list Scoop aliases

  Aliases are custom Scoop subcommands that can be created to make common tasks
easier.

To add an Alias:
    scoop alias add <name> <command> <description>

e.g.:
    scoop alias add rm 'scoop uninstall $args[0]' 'Uninstalls an app'
    scoop alias add upgrade 'scoop update *' 'Updates all apps, just like brew or apt'

Options:
  -v, --verbose   Show alias description and table headers (works only for 'list')
*)