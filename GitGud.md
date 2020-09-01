# Getting Started
This will all be written under the assumption that you are using a windows machine.

You'll want to download git to start off:
*  [git](https://git-scm.com/downloads)

You also might want to check out some of these tutorials:
* [Bitbucket](https://www.atlassian.com/git/tutorials/syncing)

## Setting up Gitlab
You'll need to [set up your ssh keys](https://git.gmu.edu/profile/keys) on this site if you haven't done so already to allow you to push to the site through ssh.

After that, you will need to request access to this group to get the permissions to push to this repository.

## Getting the Files
To retrieve the project files from the remote repository, you need to:
1.  launch git bash
2.  navigate to the place where you want to put your project files
3.  clone the remote with:
'git@github.com:jeanmarc2019/ArrowSimulation.git'

## Setting up Core for Source Control



## Git Workflow

We will be working in branches for all feature updates and bug fixes.

The workflow:
#### Setup
1. **Fetch** changes from current branch.
2. **Pull** those changes onto your local machine.

#### When working on a branch

Make sure that you periodically also pull from master, when working isolated on a branch for a while your version will look and act incredibly different from the master branch. By pulling often you will be able to slowly incorporate the changes instead of mixing in all of the changes at the end of your development

#### Pushing Changes to the git Server

1. **Stage** your changes.
2. **Commit** your changes.
3. **Push** your changes to the branch you're working on.

### Making a Branch
To make a new branch use:     
`git checkout -b "branch_name"`

### Pulling Updates
Do a `git pull origin master` to pull the latest updates from master into your local branch. 

To pull from a branch use: `git pull "branch_name"`
Make sure that you are pulling updates from "branch name" when you are on that branch.

### Checking out a Branch
To switch from branch to branch, omit the -b from the previous line:
`git checkout "branch_name"`

### Staging

To stage your files you can either add all or selectively add them.

Staging a single file:     
`git add filename`

Staging all files:    
`git add -A`

### Comitting

To commit your changes that you want in the master branch:
`git commit`      
This will pull up a text editor to enter your comments

A faster way of doing this is `git commit -m` which lets you enter your comment in the command line. 
EX:`git commit -m "Made changes to home screen"`

### Pushing to Master

To push your changes do:     
`git push -u origin branch_name`


### Merge Requests
Go to https://git.gmu.edu/gadig/collateral-damage/merge_requests  
Click the green button to make a new merge request and select your branch as source and master as target
Click compare and continue
Fill out stuff, make comments, and submit a request to be approved and merged

### Clean Up
To change back to the master branch do `git checkout master`  
  
To remove your old branch `git branch -D branch_name`

## Merging
Command to merge:

`git merge <branch-name>`

When merging errors occur you will see

`repository-name/pathpath/git-folder (branch-name|MERGING)`

Open up merging tools with

`git mergetool`

You will see the file split into three views the LOCAL, BASE and REMOTE.

Navigate with the arrow till you reach an error (usually indicated with red) and use the command

`:diffg` + either LO, BA, or RE based on the version you want to keep

EX:
`:diffg RE`

Commit any changes you've made while merging.

If you want to cancel your merge use

`git merge --abort`

### Troubleshooting
if you happen to be a dum dum who made local branches the command to fix that is
`git add -A`

also make sure you are in the lullaby-heist folder or nothing will work properly
### To Ignore a file while merging

`git merge --no-ff --no-commit <merge-branch>`

`git reset HEAD myfile.txt`

`git checkout -- myfile.txt`

`git commit -m "merged <merge-branch>`
