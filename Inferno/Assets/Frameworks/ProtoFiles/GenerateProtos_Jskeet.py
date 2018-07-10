import subprocess, os
from os import listdir

paths = os.environ.copy()

def generateProtoForFile(filename,inputDir,outputDir):
    
    namelist = filename.split('.')
    print(namelist[0])
    #csFileName = namelist[0] + ".cs";
    # csFileName = outputDir + "/" + csFileName;
    protoFileName = namelist[0] + ".proto";
    protoFileName = inputDir + "/" + protoFileName
    print(protoFileName)
    command = "protoc --proto_path=%s --csharp_out=%s %s" % (inputDir,outputDir,protoFileName);
    print(command)
    subprocess.Popen(command,shell=True)

def runProtoGeneration():
    filenames =  os.listdir(os.getcwd())
    inputDir  = os.getcwd()
    outputDir = os.path.abspath(os.path.join(inputDir,os.pardir)) + "\Protos"
    print(outputDir)
    if os.path.exists(outputDir) == False:
        os.mkdir(outputDir)

    # generateProtoForFile(file,inputDir,outputDir)

    for file in filenames:
        extension = file.split('.');
        csFileName = inputDir + "/" + extension[0] + '.cs'
        print(extension[1])
        if os.path.isfile(csFileName):
         print("File %s already Exists" % csFileName)
         continue
       
        if extension[1] == 'proto':
            generateProtoForFile(file,inputDir,outputDir)

if __name__ == '__main__':
    runProtoGeneration()
