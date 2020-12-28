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
    console.action = () => {};
    console.auth = () => {};
    console.user = () => {};
    console.state = () => {};
    
    if (config.isStateLoggingEnabled) {
        console.state = consoleLogger;
    }
    
    if (config.isUserActionLoggingEnabled) {
        console.user = consoleLogger;
    }
    
    if (config.isAuthLoggingEnabled) {
        console.auth = consoleLogger;
    }
    
    if (config.isActionLoggingEnabled) {
        console.action = consoleLogger;
    }

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