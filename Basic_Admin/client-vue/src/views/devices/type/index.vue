<script lang="ts" setup>
import { ref, h } from "vue";
import { getPageList, deleteData } from "@/api/device/device";
import { ReVxeGrid } from "@/components/ReVxeTable";
import CreateModal from "./CreateModal.vue";
import { ReDictionary } from "@/components/ReDictionary";
import { VxeUI } from "vxe-pc-ui";
const reVxeGridRef = ref();
const columns = [
  { type: "checkbox", title: "", width: 60, align: "center" },
  {
    title: "设备类型ID",
    field: "deviceTypeId",
    minWidth: 160
  },
  {
    title: "设备名称",
    field: "name",
    minWidth: 150
  },
  {
    title: "备注",
    field: "remarks",
    minWidth: 80
  },
  {
    title: "设备类型",
    field: "class",
    minWidth: 80
  }
];
const formRef = ref();

const handleReset = () => {
  formData.value = handleInitialFormParams();
};

const handleInitialFormParams = () => ({
  deviceTypeId: "",
  class: null
});

const formItems = [
  {
    field: "deviceTypeId",
    title: "设备类型ID",
    span: 6,
    itemRender: { name: "$input", props: { placeholder: "设备类型ID" } }
  },
  {
    field: "class",
    title: "设备类型",
    span: 6,
    slots: {
      default: ({ data }) => {
        return h(ReDictionary, {
          code: "dict_sensor_type",
          modelValue: data.class,
          placeholder: "请选择设备类型",
          onChange({ value }) {
            data.class = value;
          }
        });
      }
    }
  },
  {
    span: 6,
    itemRender: {
      name: "$buttons",
      children: [
        {
          props: {
            type: "submit",
            icon: "vxe-icon-search",
            content: "查询",
            status: "primary"
          }
        },
        { props: { type: "reset", icon: "vxe-icon-undo", content: "重置" } }
      ]
    }
  }
];

// 此处原本是 reactive ，但是重置的时候无法清空对话框，改成ref了
const formData = ref<{
  deviceTypeId: string;
  class: number | null;
}>(handleInitialFormParams());

const handleSearch = () => {
  reVxeGridRef.value.loadData();
};

const createModalRef = ref();
const handleAdd = () => {
  createModalRef.value.showAddModal();
};
const handleEdit = (record: Recordable) => {
  createModalRef.value.showEditModal(record);
};
const handleDelete = async (record: Recordable) => {
  const type = await VxeUI.modal.confirm("您确定要删除吗？");
  if (type == "confirm") {
    deleteData(record.id).then(() => {
      handleSearch();
    });
  }
};
const handleView = (record: Recordable) => {
  createModalRef.value.showViewModal(record);
};

const functions: Record<string, string> = {
  add: "device.type.add",
  edit: "device.type.edit",
  view: "device.type.view",
  delete: "device.type.delete"
};
</script>
<template>
  <div>
    <el-card :shadow="`never`">
      <vxe-form
        ref="formRef"
        :data="formData"
        :items="formItems"
        @submit="handleSearch"
        @reset="handleReset"
      />
    </el-card>
    <el-card :shadow="`never`" class="table-card">
      <ReVxeGrid
        ref="reVxeGridRef"
        :request="getPageList"
        :functions="functions"
        :searchParams="formData"
        :columns="columns"
        @handleAdd="handleAdd"
        @handleEdit="handleEdit"
        @handleDelete="handleDelete"
        @handleView="handleView"
      />
    </el-card>
    <CreateModal ref="createModalRef" @reload="handleSearch" />
  </div>
</template>
