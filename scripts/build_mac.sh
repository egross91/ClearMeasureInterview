# check for msbuild
if ! msbuild_loc="$(type -p "msbuild")" || [ -z "$msbuild_loc" ]; then
    echo "Cannot build project without msbuild installed."
else
    # build project using Visual Studio commands.
    proj_dir=$(cd .. && echo $PWD)
    msbuild "$proj_dir/ClearMeaureInterview.sln"
fi