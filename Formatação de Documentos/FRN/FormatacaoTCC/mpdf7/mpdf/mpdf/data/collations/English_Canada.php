#!/usr/bin/env bash
#
##############################################################################
# Copyright 2002-2011, LAMP/EPFL
# Copyright 2011-2015, JetBrains
#
# This is free software; see the distribution for copying conditions.
# There is NO warranty; not even for MERCHANTABILITY or FITNESS FOR A
# PARTICULAR PURPOSE.
##############################################################################

cygwin=false;
case "`uname`" in
    CYGWIN*) cygwin=true ;;
esac

# Based on findScalaHome() from scalac script
findKotlinHome() {
    local source="${BASH_SOURCE[0]}"
    while [ -h "$source" ] ; do
        local linked="$(readlink "$source")"
        local dir="$(cd -P $(dirname "$source") && cd -P $(dirname "$linked") && pwd)"
        source="$dir/$(basename "$linked")"
    done
    (cd -P "$(dirname "$source")/.." && pwd)
}

KOTLIN_HOME="$(findKotlinHome)"

if $cygwin; then
    # Remove spaces from KOTLIN_HOME on windows
    KOTLIN_HOME=`cygpath --windows --short-name "$KOTLIN_HOME"`
fi

[ -n "$JAVA_OPTS" ] || JAVA_OPTS="-Xmx256M -Xms32M"

declare -a java_args
declare -a kotlin_args

while [ $# -gt 0 ]; do
  case "$1" in
    -D*)
      java_args=("${java_args[@]}" "$1")
      shift
      ;;
    -J*)
      java_args=("${java_args[@]}" "${1:2}")
      shift
      ;;
    *)
      kotlin_args=("${kotlin_args[@]}" "$1")
      shift
      ;;
  esac
done

if [ -z