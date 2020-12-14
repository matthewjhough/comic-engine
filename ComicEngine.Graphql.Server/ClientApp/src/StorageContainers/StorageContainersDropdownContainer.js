import {connect} from "react-redux";
import {StorageContainersDropdown} from "./StorageContainersDropdown";
import {getStorageContainers} from "./GetStorageContainers/getStorageContainersAction";

const mapStateToProps = ({ ...rest }) => ({ ...rest });

const mapDispatchToProps = dispatch => ({
    getStorageContainers: () => dispatch(getStorageContainers())
});

export const StorageContainersDropdownContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(StorageContainersDropdown);