cmake_minimum_required(VERSION 3.10)

# 检查宏是否定义
if(DEFINED MY_MACRO)
    message(STATUS "MY_MACRO is defined with value: ${MY_MACRO}")
endif()

if(DEFINED ANOTHER_MACRO)
    message(STATUS "ANOTHER_MACRO is defined with value: ${ANOTHER_MACRO}")
endif()

project(ExecuteCommandExample)

# 定义要执行的 CMD 命令
set(MY_COMMAND "notexist.ext echo Hello, World!")

message(${MY_COMMAND})
# 使用 execute_process 执行命令
execute_process(
    COMMAND cmd.exe /c ${MY_COMMAND}
    RESULT_VARIABLE result
    OUTPUT_VARIABLE output
    ERROR_VARIABLE error_output
    WORKING_DIRECTORY ${CMAKE_CURRENT_LIST_DIR}  # 设置工作目录
)

# 输出命令的结果
message(STATUS "Command output: ${output}")
message(STATUS "Command error output: ${error_output}")
message(STATUS "Command result: ${result}")