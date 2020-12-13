/**
 * Helper method to configure whether or not the application outputs console logging.
 * @param config configuration containing boolean "isLoggingEnabled", and "isWarningEnabled"
 */
export function configureLogging(config) {
    const consoleLogger = console.log;
    const consoleWaring = console.warn;
    const consoleError = console.error;

    console.log = () => {};
    console.warn = () => {};
    console.error = () => {};

    if (config.isLoggingEnabled) {
        console.log = consoleLogger;
    }

    if (config.isWarningEnabled) {
        console.warn = consoleWaring;
    }

    if (config.isErrorEnabled) {
        console.error = consoleError;
    }
}