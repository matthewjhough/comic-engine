import {connect} from "react-redux";
import {StorageContainersDropdown} from "./StorageContainersDropdown";
import {getStorageContainers} from "./GetStorageContainers/getStorageContainersAction";
import {setSelectedStorageContainer} from "./SetSelectedStorageContainer/setSelectedStorageContainerAction"; 

const mapStateToProps = ({ ...rest }) => ({ ...rest });

const mapDispatchToProps = dispatch => ({
    getStorageContainers: () => dispatch(getStorageContainers()),
    setSelectedStorageContainer: selectedContainer => 
        dispatch(setSelectedStorageContainer(selectedContainer))
});

export const StorageContainersDropdownContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(StorageContainersDropdown);