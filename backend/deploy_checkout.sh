#!/usr/bin/env bash
# exit when any command fails
set -e

APPNAME="ecommerceapppostech"

cd ../src
func azure functionapp publish $APPNAME